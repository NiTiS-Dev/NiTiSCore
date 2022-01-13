using NiTiS.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.Core.Additions
{
    [NiTiSCoreTypeInfo("1.3.0.0", "2.0.0.0")]
    public interface ILogger
    {
        void Log(string message);
        void Clear();
    }
}
