using NiTiS.Core.Attributes;

namespace NiTiS.Core.Enums
{
    [NiTiSCoreTypeInfo("1.0.0.0", "2.0.0.0")]
    public enum DimensionAxis
    {
        X = 2,
        Y = 4,
        Z = 8,
        W = 16,
        Q = 32,
        S = 64,
        All = X | Y | Z | W | Q | S,
    }
}
