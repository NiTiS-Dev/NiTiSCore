using System.Collections.Generic;

namespace NiTiS.Additions;

public delegate T Dipper<T>(T item);

public delegate bool Validator<in T>(T item);
public delegate bool Validator<in T1, in T2>(T1 item1, T2 item2);
public delegate bool Validator<in T1, in T2, in T3>(T1 item1, T2 item2, T3 item3);
public delegate bool Validator<in T1, in T2, in T3, in T4>(T1 item1, T2 item2, T3 item3, T4 item4);

public delegate TOut Cast<in T, out TOut>(T item);

public delegate void Iterator<in T>(T item);

/// <summary>
/// Iterate objects by predicate
/// </summary>
/// <typeparam name="T">Type of iterable objects</typeparam>
public record struct SmartIterator<T>(Validator<T> Validator, Iterator<T> Iterator)
{
	public IEnumerable<T> Iterate(IEnumerable<T> enumerable)
	{
		foreach(T item in enumerable)
		{
			if (Validator(item))
			{
				Iterator(item);
				yield return item;
			}
		}
	}
}
/// <summary>
/// Cast object to other type and iterate by predicate
/// </summary>
/// <typeparam name="T">Type of input iterable objects</typeparam>
/// <typeparam name="TCast">Type of iterable objects</typeparam>
public record struct SmartIterator<T, TCast>(Cast<T, TCast> Cast, Validator<TCast> Validator, Iterator<TCast> Iterator)
{
	public IEnumerable<TCast> Iterate(IEnumerable<T> enumerable)
	{
		foreach (T item in enumerable)
		{
			TCast castedItem = Cast(item);
			if (Validator(castedItem))
			{
				Iterator(castedItem);
				yield return castedItem;
			}
		}
	}
}

public static class Functions
{
	public static void Iterate<T>(this IEnumerable<T> enumerable, Iterator<T> iterator)
	{
		foreach (T item in enumerable)
		{
			iterator(item);
		}
	}
	public static IEnumerable<T> Iterate<T>(this IEnumerable<T> enumerable, SmartIterator<T> iterator)
	{
		return iterator.Iterate(enumerable);
	}
	public static IEnumerable<TCast> Iterate<T, TCast>(this IEnumerable<T> enumerable, SmartIterator<T, TCast> iterator)
	{
		return iterator.Iterate(enumerable);
	}
}