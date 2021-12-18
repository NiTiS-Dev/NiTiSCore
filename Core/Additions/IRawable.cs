namespace NiTiS.Core.Additions
{
    public interface IRawable
    {

    }
    public interface IRawable<RAW> : IRawable
    {
        void Restore(RAW rawData);
        RAW GetRaw();
    }
}
