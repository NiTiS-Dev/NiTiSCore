using NiTiS.Core.Attributes;

namespace NiTiS.Core.Additions
{
    [NiTiSCoreTypeInfo("2.0.0.0", "2.0.0.0")]
    public class Link<CONNECT> where CONNECT : struct
    {
        public CONNECT Value { get; set; }
        public Link(CONNECT value)
        {
            Value = value;
        }
        public Link()
        {
            Value = new CONNECT();  
        }
    }
}
