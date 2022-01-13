namespace NiTiS.Core.Additions
{
    public struct ReadonlyStorage<STORED> where STORED : class
    {
        public STORED Value { get; private set; }
        public ReadonlyStorage(STORED value)
        {
            Value = value;
        }
    }
}
