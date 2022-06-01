// The NiTiS-Dev licenses this file to you under the MIT license.

using System;

namespace NiTiS.Math;
public struct Ranged<T> : IRangedVar<T>, IEquatable<IRangedVar<T>>, IEquatable<T> where T : unmanaged, IEquatable<T>, IComparable<T>
{
	private readonly T min, max;
	private T value;
	public Ranged(T min, T max, T value)
	{
		this.min = min;
		this.max = max;
		if (0 < min.CompareTo(max))
			throw new ArithmeticException("Min value are bigger then max value");
		this.value = value;
		SetValue(value);
	}
	public T MaxValue => max;
	public T MinValue => min;
	public T Value => value;

	public bool Equals(T other) 
		=> value.Equals(other);
	public bool Equals(IRangedVar<T>? other)
		=> value.Equals(other);
	public override bool Equals(object? obj)
		=> obj is not null && (obj is T item ? Equals(item) : obj is IRangedVar<T> ranged ? Equals(ranged) : false);
	public override string? ToString() => value.ToString();
	public void SetValue(T value)
	{
		int minComp = this.min.CompareTo(value);
		int maxComp = this.max.CompareTo(value);
		if (minComp >= 0) { this.value = min; }
		else if (maxComp <= 0) { this.value = max; }
		else { this.value = value; }
	}
	public override int GetHashCode()
#if NET48
	{
		int hashCode = 1541899794;
		hashCode = hashCode * -1521134295 + this.min.GetHashCode();
		hashCode = hashCode * -1521134295 + this.max.GetHashCode();
		hashCode = hashCode * -1521134295 + this.value.GetHashCode();
		return hashCode;
	}
#else
		=> HashCode.Combine(this.min, this.max, this.value);
#endif

	public static Ranged<T> operator +(Ranged<T> left, IRangedVar<T> right)
	{
		left.SetValue(GenericCalculator<T, T, T>.Addition(left.Value, right.Value));
		return left;
	}
	public static Ranged<T> operator +(Ranged<T> left, T right)
	{
		left.SetValue(GenericCalculator<T, T, T>.Addition(left.Value, right));
		return left;
	}
	public static Ranged<T> operator -(Ranged<T> left, IRangedVar<T> right)
	{
		left.SetValue(GenericCalculator<T, T, T>.Substract(left.Value, right.Value));
		return left;
	}
	public static Ranged<T> operator -(Ranged<T> left, T right)
	{
		left.SetValue(GenericCalculator<T, T, T>.Substract(left.Value, right));
		return left;
	}
	public static Ranged<T> operator /(Ranged<T> left, IRangedVar<T> right)
	{
		left.SetValue(GenericCalculator<T, T, T>.Divide(left.Value, right.Value));
		return left;
	}
	public static Ranged<T> operator /(Ranged<T> left, T right)
	{
		left.SetValue(GenericCalculator<T, T, T>.Divide(left.Value, right));
		return left;
	}
	public static Ranged<T> operator *(Ranged<T> left, IRangedVar<T> right)
	{
		left.SetValue(GenericCalculator<T, T, T>.Multiply(left.Value, right.Value));
		return left;
	}
	public static Ranged<T> operator *(Ranged<T> left, T right)
	{
		left.SetValue(GenericCalculator<T, T, T>.Multiply(left.Value, right));
		return left;
	}
	public static bool operator ==(Ranged<T> left, IRangedVar<T> right)
		=> left.Equals(right);
	public static bool operator !=(Ranged<T> left, IRangedVar<T> right)
		=> !left.Equals(right);
	public static bool operator ==(Ranged<T> left, T right)
		=> left.Equals(right);
	public static bool operator !=(Ranged<T> left, T right)
		=> !left.Equals(right);
}
