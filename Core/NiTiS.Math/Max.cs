
/* Необъединенное слияние из проекта "NiTiS.Math (net48)"
До:
using System;
После:
using NiTiS;
using NiTiS.Math;
using NiTiS.Math;
using NiTiS.Math.Ranged;
using System;
*/
using System;

namespace NiTiS.Math;

/// <summary>
/// Sets the maximum value of the given type
/// </summary>
/// <typeparam name="T">The type for compair</typeparam>
public readonly struct Max<T> : IComparable<T>, IComparable<Max<T>>, IComparable<Min<T>>, IEquatable<T>, IEquatable<Max<T>>, IEquatable<Min<T>> where T : IComparable
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
			value = right;
		else
			value = left.value;
		return new Max<T>(value);
	}
	public Max()
	{
#pragma warning disable CS8601
		this.value = default;
#pragma warning restore CS8601
		if (value is null) throw new ArgumentNullException(nameof(value));
	}
	public Max(T value) => this.value = value;
	/// <inheritdoc/>
	public int CompareTo(T? other) => other is null ? throw new ArgumentNullException(nameof(other)) : value.CompareTo(other);
	/// <inheritdoc/>
	public int CompareTo(Max<T> other) => value.CompareTo(other.value);
	/// <inheritdoc/>
	public int CompareTo(Min<T> other) => value.CompareTo(other.value);
	/// <inheritdoc/>
	public bool Equals(T? other) => this.value.Equals(other);
	/// <inheritdoc/>
	public bool Equals(Max<T> other) => this.value.Equals(other.value);
	/// <inheritdoc/>
	public bool Equals(Min<T> other) => this.value.Equals(other.value);
	/// <inheritdoc/> 
	public override string? ToString() => this.value.ToString();

	public override bool Equals(object? obj)
	{
		if (obj is Max<T> max) return Equals(max); 		if (obj is Min<T> min) return Equals(min); 		if (obj is T item) return Equals(item); 		return false;
	}

	public override int GetHashCode()
		=> this.value.GetHashCode();

	public static bool operator ==(Max<T> left, Max<T> right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(Max<T> left, Max<T> right)
	{
		return !(left == right);
	}

	public static bool operator <(Max<T> left, Max<T> right)
	{
		return left.CompareTo(right) < 0;
	}

	public static bool operator <=(Max<T> left, Max<T> right)
	{
		return left.CompareTo(right) <= 0;
	}

	public static bool operator >(Max<T> left, Max<T> right)
	{
		return left.CompareTo(right) > 0;
	}

	public static bool operator >=(Max<T> left, Max<T> right)
	{
		return left.CompareTo(right) >= 0;
	}
}
