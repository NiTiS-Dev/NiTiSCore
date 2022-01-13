using NiTiS.Core.Attributes;
using System;

namespace NiTiS.Core.Additions
{
    [Obsolete]
    [NiTiSCoreTypeInfo("1.3.0.0", "2.0.0.0")]
    public interface IRawable
    {

    }
    [Obsolete]
    [NiTiSCoreTypeInfo("1.3.0.0", "2.0.0.0")]
    public interface IRawable<RAW> : IRawable
    {
        void Restore(RAW rawData);
        RAW GetRaw();
    }
}
