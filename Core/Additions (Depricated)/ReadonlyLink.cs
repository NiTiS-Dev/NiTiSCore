namespace NiTiS.Core.Additions
{
    public class ReadonlyLink<CONNECT>
    {
        public CONNECT Value { get; private set; }
        public ReadonlyLink(CONNECT value)
        {
            Value = value;
        }
    }
}
