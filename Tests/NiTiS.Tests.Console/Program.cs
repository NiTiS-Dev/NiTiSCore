using NiTiS.IO;

namespace NiTiS.Tests.Console
{
	public class Program
	{
		private static void Main(string[] args)
		{
			MemorySize size1 = new(1024);
			MemorySize size2 = new(1000);

			SC.WriteLine(size2 < size1);
			SC.WriteLine(size2 * 2 < size1);
		}
	}
}