using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiTiS.Additions;

public static class Enumerable
{
	public static IEnumerable<T> SkipLast<T>(this IEnumerable<T> enumerable, int count)
	{
		int size = 0;
		foreach(T i in enumerable)
		{
			size++;
		}
		foreach(T i in enumerable)
		{
			if (size-- - count == 0) yield break;
			yield return i;
		}
	}
}
