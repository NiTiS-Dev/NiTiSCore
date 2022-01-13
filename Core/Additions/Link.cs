namespace NiTiS.Core.Additions
{
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
