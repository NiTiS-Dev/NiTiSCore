using System;

namespace NiTiS.Math.Ranged;

/// <summary>
/// Sets the minimum value of the given type
/// </summary>
/// <typeparam name="T">The type for compair</typeparam>
public readonly struct Min<T> : IComparable<T>, IComparable<Min<T>>, IEquatable<T>, IEquatable<Min<T>> where T : IComparable
{
	/// <summary>
	/// Single field, who contains value
	/// </summary>
	public readonly T value;
	/// <summary>
	/// Returns the minimum value from two values
	/// </summary>
	/// <param name="left">Dominant value</param>
	/// <param name="right">Second value</param>
	/// <returns>Choise the minimum value</returns>
	public static Min<T> operator |(Min<T> left, T right)
	{
		int comp = left.CompareTo(right);
		T value;
		if (comp < 0)
		{
			value = left.value;
		}
		else if (comp > 0)
		{
			value = right;
		}else
		{
			value = left.value;
		}
		return new Min<T>(value);
	}
	public Min()
	{
#pragma warning disable CS8601
		this.value = default;
#pragma warning restore CS8601
		if (value is null) throw new ArgumentNullException(nameof(value));
	}
	public Min(T value) => this.value = value;
	public int CompareTo(T? other) => other is null ? throw new ArgumentNullException(nameof(other)) : value.CompareTo(other);
	public int CompareTo(Min<T> other) => value.CompareTo(other.value);
	public bool Equals(T? other) => this.value.Equals(other);
	public bool Equals(Min<T> other) => this.value.Equals(other.value);
	public override string? ToString() => this.value.ToString();
}
