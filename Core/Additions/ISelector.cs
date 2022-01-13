using NiTiS.Core.Attributes;

namespace NiTiS.Core.Additions
{
    [NiTiSCoreTypeInfo("2.0.0.0", "2.0.0.0")]
    internal interface ISelector
    {
        int Matchs { get; }
        string Convert(string value, bool invert = false);       
    }
}
