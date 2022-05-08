using NiTiS.Collections.Generic;

namespace NiTiS.Tests.Console
{
	public class Program
	{
		private static void Main(string[] args)
		{
			Sequence<char> seq = new(2);
			SC.WriteLine(seq.LengthLimit);
			seq.Add('2');
			SC.WriteLine(seq.LengthLimit);
			seq.Add('a');
			SC.WriteLine(seq.LengthLimit);
			seq.Add('b');
			SC.WriteLine(seq.LengthLimit);
			seq.Add('c');
			SC.WriteLine(seq.Length);
			SC.WriteLine(seq.LengthLimit);
			SC.WriteLine(seq);
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