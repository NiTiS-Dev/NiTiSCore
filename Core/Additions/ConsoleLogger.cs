using NiTiS.Core.Attributes;
using System;

namespace NiTiS.Core.Additions
{
    [NiTiSCoreTypeInfo("1.3.0.0", "2.0.0.0")]
    public class ConsoleLogger : ILogger
    {
        public void Clear()
        {
            Console.Clear();
        }
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
