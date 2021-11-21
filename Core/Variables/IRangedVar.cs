namespace NiTiS.Core.Variables
{
    public interface IRangedVar<T>
    {
        void SetValue(T value);
        T MaxValue();
        T MinValue();
        T Value();
    }
}
