using System;

namespace NiTiS.Core.Additions
{
    [Obsolete]
    public interface IRawable
    {

    }
    [Obsolete]
    public interface IRawable<RAW> : IRawable
    {
        void Restore(RAW rawData);
        RAW GetRaw();
    }
}
