namespace NiTiS.Core.Additions
{
    public class Link<CONNECT>
    {
        public CONNECT Value { get; set; }
        public Link(CONNECT value)
        {
            Value = value;
        }
    }
}
