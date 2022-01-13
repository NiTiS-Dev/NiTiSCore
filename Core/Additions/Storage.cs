namespace NiTiS.Core.Additions
{
    public struct Storage<STORED> where STORED : class
    {
        public STORED Value { get; set; }
        public Storage(STORED value)
        {
            Value = value;
        }
    }
}
