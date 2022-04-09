using NiTiS.Math.Ranged;

namespace NiTiS.Tests.Console
{
	public class Program
	{
		private static unsafe void Main(string[] args)
		{
			Max<int> maxX = new(4);
			Min<int> minX = new(4);
			maxX |= -1;
			minX |= -2;
			SC.WriteLine(maxX);
			SC.WriteLine(minX);
		}
	}
}