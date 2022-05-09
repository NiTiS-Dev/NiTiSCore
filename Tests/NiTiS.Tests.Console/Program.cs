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
}