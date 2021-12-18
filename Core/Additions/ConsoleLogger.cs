using System;

namespace NiTiS.Core.Additions
{
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
