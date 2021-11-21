namespace NiTiS.Core.Variables
{
    public interface IVector<T>
    {
        int GetDimensionCount();
#if NETCOREAPP3_1_OR_GREATER
        T GetValueByDimension(string dimension) => GetValueByDimension(dimension[0]);
#else
#endif
        T GetValueByDimension(char dimension);
    }
}
