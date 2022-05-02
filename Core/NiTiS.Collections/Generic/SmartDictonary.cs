using System.Collections.Generic;
using System.Linq;

namespace NiTiS.Collections.Generic;

public class SmartDictonary<TKey, TValue> : Dictionary<TKey, TValue> where TKey : notnull
{
	public delegate TKey KeyGetter(TValue key);
	protected readonly KeyGetter keyGetter;
	public SmartDictonary(KeyGetter keyGetter)
	{
		this.keyGetter = keyGetter;
	}
	public SmartDictonary(KeyGetter keyGetter, IDictionary<TKey, TValue> dictionary) : base(dictionary)
	{
		this.keyGetter = keyGetter;
	}
	public SmartDictonary(KeyGetter keyGetter, IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey>? comparer) : base(dictionary, comparer)
	{
		this.keyGetter = keyGetter;
	}
	public SmartDictonary(KeyGetter keyGetter, int capacity) : base(capacity)
	{
		this.keyGetter = keyGetter;
	}
	public SmartDictonary(KeyGetter keyGetter, int capacity, IEqualityComparer<TKey>? comparer) : base(capacity, comparer)
	{
		this.keyGetter = keyGetter;
	}

#if NITIS_MORE_CONSTRUCTOR_SMARTDICTONARY
	public SmartDictonary(KeyGetter keyGetter, IEnumerable<KeyValuePair<TKey, TValue>> collection) : base(collection)
	{
		this.keyGetter = keyGetter;
	}
	public SmartDictonary(KeyGetter keyGetter, IEnumerable<KeyValuePair<TKey, TValue>> collection, IEqualityComparer<TKey>? comparer) : base(collection, comparer)
	{
		this.keyGetter = keyGetter;
	}
	public SmartDictonary(KeyGetter keyGetter, IEnumerable<TValue> collection) : base(collection.Select(s => new KeyValuePair<TKey, TValue>(keyGetter(s), s)))
	{
		this.keyGetter = keyGetter;
	}
	public SmartDictonary(KeyGetter keyGetter, IEnumerable<TValue> collection, IEqualityComparer<TKey>? comparer) : base(collection.Select(s => new KeyValuePair<TKey, TValue>(keyGetter(s), s)), comparer)
	{
		this.keyGetter = keyGetter;
	}
#endif
	public void Add(TValue value)
	{
		base.Add(keyGetter(value), value);
	}
	public void Remove(TValue value)
	{
		base.Remove(keyGetter(value));
	}
	public void Remove(TValue value, out TKey key)
	{
		key = keyGetter(value);
		base.Remove(key);
	}
}
