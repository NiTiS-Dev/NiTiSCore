using NiTiS.Core.Attributes;

namespace NiTiS.Core.Additions
{
    [NiTiSCoreTypeInfo("2.0.0.0", "2.0.0.0")]
    public class ReadonlyLink<CONNECT> where CONNECT : struct
    {
        public CONNECT Value { get; private set; }
        public ReadonlyLink(CONNECT value)
        {
            Value = value;
        }
    }
}
