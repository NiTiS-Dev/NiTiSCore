namespace NiTiS.Core.Variables
{
    public interface IRangedVar<T>
    {
        public void SetValue(T value);
        public T MaxValue();
        public T MinValue();
        public T Value();
    }
}
