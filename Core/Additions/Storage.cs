using NiTiS.Core.Attributes;

namespace NiTiS.Core.Additions
{
    [NiTiSCoreTypeInfo("2.0.0.0", "2.0.0.0")]
    public struct Storage<STORED> where STORED : class
    {
        public STORED Value { get; set; }
        public Storage(STORED value)
        {
            Value = value;
        }
    }
}
