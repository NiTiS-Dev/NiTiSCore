using NiTiS.Core.Enums;

namespace NiTiS.Core.Types
{
    public interface IVector
    {
    }
    public interface IVector<T> : IVector
    {
        T GetValueByDimension(DimensionAxis axis);
    }

    public interface IRationalVector
    {
        double Length
        {
            get
#if NETCOREAPP3_1_OR_GREATER
                => System.Math.Sqrt(LengthSquared);
#else
                ;
#endif
        }
        double LengthSquared { get; }
        void Normalize();
    }
}
