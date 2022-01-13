using NiTiS.Core.Attributes;

namespace NiTiS.Core.Additions
{
    [NiTiSCoreTypeInfo("2.0.0.0", "2.0.0.0")]
    public struct ReadonlyStorage<STORED> where STORED : class
    {
        public STORED Value { get; private set; }
        public ReadonlyStorage(STORED value)
        {
            Value = value;
        }
    }
}
