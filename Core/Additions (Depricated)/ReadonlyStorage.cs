namespace NiTiS.Core.Additions
{
    public struct ReadonlyStorage<STORED>
    {
        public STORED Value { get; private set; }
        public ReadonlyStorage(STORED value)
        {
            Value = value;
        }
    }
}
