using NiTiS.Math;

namespace NiTiS.Tests.Console
{
	public static unsafe class Program
	{
		private static void Main()
		{
			Ranged<int> range = new(2, 4, 3);
			SC.WriteLine(range);
			range.SetValue(1);
			SC.WriteLine(range);
		}
	}
}