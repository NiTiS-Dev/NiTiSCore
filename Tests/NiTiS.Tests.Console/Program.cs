using NiTiS.Collections.Generic;
using NiTiS.Math;

namespace NiTiS.Tests.Console
{
	public static unsafe class Program
	{
		private static void Main()
		{
			Sequence<int> sequence = new(16);
			sequence.Add(1);
			SC.WriteLine(sequence.LengthLimit);
		}
	}
}