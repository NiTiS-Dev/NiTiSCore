using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace NiTiS.Collections.Generic;

/// <summary>
/// Readonly collection
/// </summary>
/// <typeparam name="T"></typeparam>
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public unsafe class Sequence<T> : IEnumerable<T>
{
	private IEqualityComparer<T> comparer;
	private T[] block;
	/// <summary>
	/// Current size of array
	/// </summary>
	private ulong size = 0;
	/// <summary>
	/// Size limit of array
	/// </summary>
	private ulong maxSize;
	/// <summary>
	/// Get current length of array
	/// </summary>
	public ulong Length => size;
	/// <summary>
	/// Get current max length of array (may changing at time)
	/// </summary>
	public ulong LengthLimit => maxSize;
	public T this[ulong index] => block[index];
	public Sequence() : this(16, EqualityComparer<T>.Default) { }
	public Sequence(ulong size) : this(size, EqualityComparer<T>.Default) { }
	public Sequence(IEqualityComparer<T> equalityComparer) : this(16, equalityComparer) { }
	public Sequence(ulong startSize, IEqualityComparer<T> equalityComparer)
	{
		if (startSize < 1) throw new ArgumentException("0 is invalid length");
		this.block = new T[startSize];
		this.maxSize = startSize;
		this.comparer = equalityComparer;
	}
	public void Add(T item)
	{
		block[size] = item;
		size++;
		CheckArray();
	}
	//TODO: Decline to use Add method
	public void AddRange(params T[] items)
	{
		foreach(T item in items)
		{
			Add(item);
		}
	}
	/// <summary>
	/// 
	/// </summary>
	/// <param name="item"></param>
	/// <returns><see cref="UInt64.MaxValue"/> when not found</returns>
	public ulong IndexOf(T item)
	{
		ulong index = 0;
		foreach (T eachItem in block)
		{
			if (comparer.Equals(item, eachItem)) return index;
			index++;
		}
		return UInt64.MaxValue;
 	}
	public T GetValue(ulong index)
		=> block[index];

	/// <summary>
	/// Check if array is overfull
	/// </summary>
	protected void CheckArray()
	{
		if (size == maxSize)
		{
			T[] newBlock = new T[maxSize *= 2];
			block.CopyTo(newBlock, 0);
			block = newBlock;
		}
	}
	/// <inheritdoc/>
	public IEnumerator<T> GetEnumerator()
	{
		foreach (T item in block)
		{
			yield return item;
		}
	}
	/// <inheritdoc/>
	IEnumerator IEnumerable.GetEnumerator() => this.block.GetEnumerator();
	public override string ToString() => GetType().Name.Split('`')[0] + "<" + typeof(T).Name + ">";

	private string GetDebuggerDisplay()
		=> $"{{{typeof(T).Name} ({Length})}}";
}