using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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
	/// <summary>
	/// Add item to end of sequence
	/// </summary>
	/// <param name="item"></param>
	public void Add(T item)
	{
		block[size] = item;
		size++;
		CheckArray();
	}
	/// <summary>
	/// Add range of items to end of sequence
	/// </summary>
	/// <param name="items"><see cref="IEnumerable{T}"/> object with range of <typeparamref name="T"/></param>
	public void AddRange(IEnumerable<T> items)
		=> AddRange(items.ToArray());
	/// <summary>
	/// Add range of items to end of sequence
	/// </summary>
	/// <param name="items">Array of <typeparamref name="T"/></param>
	public void AddRange(params T[] items)
	{
		ulong lenght = (ulong)items.Length;
		ulong newSize = size + lenght;
		ulong first = size;

		size = newSize;
		if (newSize > maxSize) CheckArray();

		for (ulong i = 0; i < lenght; i++)
		{
			this.block[first + i] = items[i];
		}
	}
	/// <summary>
	/// Return index of item in sequence
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
		while (size >= maxSize)
		{
			T[] newBlock = new T[maxSize *= 2];
			block.CopyTo(newBlock, 0);
			block = newBlock;
		}
	}
	/// <inheritdoc/>
	public IEnumerator<T> GetEnumerator()
	{
		for (ulong i = 0; i < size; i++)
		{
			yield return block[i];
		}
	}
	/// <inheritdoc/>
	IEnumerator IEnumerable.GetEnumerator() 
		=> this.block.GetEnumerator();
	public override string ToString() 
		=> GetType().Name.Split('`')[0] + "<" + typeof(T).Name + ">";
	private protected string GetDebuggerDisplay()
		=> $"{{{typeof(T).Name} ({Length})}}";
}
