namespace NiTiS.Core.Additions
{
    internal interface ISelector
    {
        int Matchs { get; }
        string Convert(string value, bool invert = false);
    }
}
