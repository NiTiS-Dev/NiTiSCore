namespace NiTiS.Core.Types
{
    public interface IRangedVar<T>
    {
        void SetValue(T value);
        T MaxValue();
        T MinValue();
        T Value();
    }
}
