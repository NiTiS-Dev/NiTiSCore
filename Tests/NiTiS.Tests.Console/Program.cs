using NiTiS.Math;
using NiTiS.Math.Ranged;
using NiTiS.RawSalt.Registry;
using NiTiS.Reflection;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace NiTiS.Tests.Console
{
	public class Program
	{
		private static void Main(string[] args)
		{
			Registrator<string> reg = Registrator.GetRegistry<string>();
			for (int i = 0; i < 32; i++)
			{
				reg.Registry(new(new("global", "s" + i), ""));
				SC.WriteLine(i);
			}
		}

		[CompilerGenerated]
		protected class D
		{
			private readonly int x = 76;
			private readonly string df = "";
			private Lazy<string> fd;
			private static string dasd = "";
			private static readonly string static_dasd;
			public string SFsgd { get; set; }
			public override string ToString() => x.ToString();
			private static void SSADFS() { }
		}
	}
}