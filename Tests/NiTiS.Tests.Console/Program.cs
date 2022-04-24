using NiTiS.IO.Format.TABS;

namespace NiTiS.Tests.Console
{
	public class Program
	{
		private static void Main(string[] args)
		{
			string tabsExample =
@"
m_int: 213
globality:
		size: 4
	arr: [
		's',
		'q',
		'0',
		'3'
	] 
";
			string tabs = TABSSerializer.Serialize(new AFD());
			string tabs3 = TABSSerializer.Serialize(new string[] { "asdf", "assdf" });

			SC.WriteLine(TABSSerializer.ParseObject(tabsExample));
			SC.WriteLine("------");
			SC.WriteLine(TABSSerializer.Deserialize<AFD>(tabs));
			SC.WriteLine("------");
			SC.WriteLine(tabs3);
		}
	}
	public class AFD
	{
		private string amogus;
		public Gogol gogoliza = new();
		public override string ToString()
		{
			return $"{amogus} and {gogoliza}";
		}
	}
	public struct Gogol
	{
		private string amogus;
		public Gogol()
		{
			this.amogus = "adsffdas";
		}
		public override string ToString() => amogus;
	}
}