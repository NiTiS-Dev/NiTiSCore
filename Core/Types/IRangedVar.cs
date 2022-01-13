namespace NiTiS.Core.Types
{
    public interface IRangedVar<T>
    {
        /// <summary>
        /// Sets the value according to the rules no more no less
        /// </summary>
        /// <param name="value">The value to be set. If the value is not included in the maximum or minimum border, it will be truncated</param>
        void SetValue(T value);
        /// <summary>
        /// Returns the maximum value of variable
        /// </summary>
        T MaxValue { get; }
        /// <summary>
        /// Returns the minimum value of variable
        /// </summary>
        T MinValue { get; }
        /// <summary>
        /// Returns the value of variable
        /// </summary>
        T Value { get; }
    }
}
