using SC = System.Console;
using NiTiS.Core;
using System.Runtime.InteropServices;

namespace NiTiS.Tests.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach(var asm in NiTiSCoreLib.BasicLibs)
            {
                object[] attribs = asm.GetCustomAttributes(typeof(GuidAttribute), true);
                var guidAttr = (GuidAttribute)attribs[0];
                SC.WriteLine(guidAttr.Value);
            }
        }
    }
}