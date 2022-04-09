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
		foreach(T i in @this)
		{
			yield return i;
		}
		foreach(T i in range)
		{
			yield return i;
		}
	}
}
