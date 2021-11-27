using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.Core.Additions
{
    public interface ILogger
    {
        void Log(string message);
        void Clear();
    }
}
