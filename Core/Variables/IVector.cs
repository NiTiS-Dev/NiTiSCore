namespace NiTiS.Core.Variables
{
    public interface IVector<T>
    {
        int GetDimensionCount();
        T GetValueByDimension(string dimension) => GetValueByDimension(dimension[0]);
        T GetValueByDimension(char dimension);
    }
}
