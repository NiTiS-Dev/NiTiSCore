using System;

namespace NiTiS.Math.Ranged;

/// <summary>
/// Sets the maximum value of the given type
/// </summary>
/// <typeparam name="T">The type for compair</typeparam>
public readonly struct Max<T> : IComparable<T>, IComparable<Max<T>>, IEquatable<T>, IEquatable<Max<T>> where T : IComparable
{
	/// <summary>
	/// Single field, who contains value
	/// </summary>
	public readonly T value;
	/// <summary>
	/// Returns the maximum value from two values
	/// </summary>
	/// <param name="left">Dominant value</param>
	/// <param name="right">Second value</param>
	/// <returns>Choise the maximum value</returns>
	public static Max<T> operator |(Max<T> left, T right)
	{
		int comp = left.CompareTo(right);
		T value;
		if (comp < 0)
		{
			value = right;
		}else
		{
			value = left.value;
		}
		return new Max<T>(value);
	}
	public Max()
	{
		this.value = default;
		if (value is null) throw new ArgumentNullException(nameof(value));
	}
	public Max(T value) => this.value = value;
	public int CompareTo(T? other) => other is null ? throw new ArgumentNullException(nameof(other)) : value.CompareTo(other);
	public int CompareTo(Max<T> other) => value.CompareTo(other.value);
	public bool Equals(T other) => this.value.Equals(other);
	public bool Equals(Max<T> other) => this.value.Equals(other.value);
	public override string? ToString() => this.value.ToString();
}
