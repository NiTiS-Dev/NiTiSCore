using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiTiS.Collections;

public static class Enumerable
{
	public static IEnumerable<T> AppendRange<T>(this IEnumerable<T> @this, IEnumerable<T> range)
	{
		foreach (T item in @this)
		{
			yield return item;
		}
		foreach (T item in range)
		{
			yield return item;
		}
	}
	public static IEnumerable<T> AppendRangeAtBegin<T>(this IEnumerable<T> @this, IEnumerable<T> range)
	{
		foreach (T item in range)
		{
			yield return item;
		}
		foreach (T item in @this)
		{
			yield return item;
		}
	}
	public static IEnumerable<T> AppendAtBegin<T>(this IEnumerable<T> @this, T obj)
	{
		yield return obj;
		foreach (T item in @this)
		{
			yield return item;
		}
	}
	public static IEnumerable<T> ForEach<T>(this IEnumerable<T> @this, Action<T> action)
	{
		foreach (T item in @this)
		{
			action(item);
		}
		return @this;
	}
}
