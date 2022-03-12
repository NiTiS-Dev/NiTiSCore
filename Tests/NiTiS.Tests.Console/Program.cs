using SC = System.Console;
using NiTiS.IO;

namespace NiTiS.Tests.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            File file = new(@"C:/Desktop/main.nit");
            SC.WriteLine(file.Parent);
            Directory dir = new(@"C:/Desktop/Folder");
            dir.Create();
            File f = new(dir, "item.int");
            f.Create();
        }
    }
}
