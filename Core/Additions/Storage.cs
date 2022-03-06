namespace NiTiS.Core.Additions
{
    public struct Storage<STORED>
    {
        public STORED Value { get; set; }
        public Storage(STORED value)
        {
            Value = value;
        }
    }
}
