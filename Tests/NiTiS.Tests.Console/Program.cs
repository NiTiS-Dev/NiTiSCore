using SC = System.Console;
using NiTiS.IO;
using NiTiS.Additions;

namespace NiTiS.Tests.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3 };
            

            SC.WriteLine(Strings.FromArray(numbers));
        }
    }
}
