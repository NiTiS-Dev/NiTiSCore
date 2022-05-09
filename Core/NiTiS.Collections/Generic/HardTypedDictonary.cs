using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace NiTiS.Collections.Generic;

public class HardTypedDictonary : HardTypedDictonary<object> { }
public class HardTypedDictonary<M> : IEnumerable<M>
{
	private readonly Dictionary<Type, M> dict = new();

	public HardTypedDictonary() { }
	public HardTypedDictonary(IEnumerable<M> items)
	{
		foreach (M? item in items)
		{
			if (item is null)
			{
				continue;
			}
			dict.Add(item.GetType(), item);
		}
	}
	public void Add(M obj) => this.dict.Add(obj!.GetType(), obj);
	public void Add(Type type, object obj)
	{
		if (obj is M m)
		{
			this.dict.Add(type, m);
		}
	}

	public void Clear() => this.dict.Clear();
	public int Count => this.dict.Count;
	public bool Exists<T>() => this.dict.ContainsKey(typeof(T));
	public bool Exists(Type item) => this.dict.ContainsKey(item);

	internal Dictionary<Type, M> Dictonary => dict;
	public object? Get(Type type) => dict[type];
	public T? Get<T>() where T : M => (T?)dict[typeof(T)];
	public IEnumerator<M> GetEnumerator() => this.dict.Select( s=> s.Value).GetEnumerator();
	IEnumerator IEnumerable.GetEnumerator() => this.dict.GetEnumerator();
	public IEnumerator<M> GetEnumeratorAsList()
	{
		foreach (KeyValuePair<Type, M> item in dict)
		{
			yield return item.Value;
		}
	}
	public IEnumerator<M> GetEnumeratorFromValues() => this.dict.Values.GetEnumerator();
	public bool Remove<T>() where T : M => this.dict.Remove(typeof(T));
 	public bool Remove(Type item) => this.dict.Remove(item);
}
