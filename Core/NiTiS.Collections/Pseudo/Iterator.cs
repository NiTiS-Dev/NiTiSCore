using System;

namespace NiTiS.Collections.Pseudo;

[Obsolete]
public static class Iterator
{
	public static void Range(Iterate iterator, int start, int end)
	{
		while (start <= end)
		{
			iterator(start);
			start++;
		}
	}
	public static void Range(Iterate iterator, int start, uint amount)
	{
		for (uint i = 0; i < amount; i++)
		{
			iterator(start);
			start++;
		}
	}
}
public delegate void Iterate(int index);
