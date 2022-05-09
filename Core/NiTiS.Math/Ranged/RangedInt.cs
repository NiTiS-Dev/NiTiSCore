using System;
using System.Diagnostics;

namespace NiTiS.Math.Ranged;

[DebuggerDisplay("Int ({MinValue}~{Value}~{MaxValue})")]
public struct RangedInt : IRangedVar<int>, IEquatable<RangedInt>, IEquatable<int>
{
	private int value;
	private int min, max;
	public int MaxValue => max;
	public int MinValue => min;
	public int Value => value;
	public void SetValue(int value)
	{
		if (value < min)
		{
			this.value = min;
		}
		else if (value > max)
		{
			this.value = max;
		}
		else
		{
			this.value = value;
		}
	}

	public static RangedInt operator +(RangedInt left, IRangedVar<int> right)
	{
		left.SetValue(left.Value + right.Value);
		return left;
	}
	public static RangedInt operator +(RangedInt left, int right)
	{
		left.SetValue(left.Value + right);
		return left;
	}
	public static RangedInt operator -(RangedInt left, IRangedVar<int> right)
	{
		left.SetValue(left.Value - right.Value);
		return left;
	}
	public static RangedInt operator -(RangedInt left, int right)
	{
		left.SetValue(left.Value - right);
		return left;
	}
	public static RangedInt operator /(RangedInt left, IRangedVar<int> right)
	{
		left.SetValue(left.Value / right.Value);
		return left;
	}
	public static RangedInt operator /(RangedInt left, int right)
	{
		left.SetValue(left.Value / right);
		return left;
	}
	public static RangedInt operator *(RangedInt left, IRangedVar<int> right)
	{
		left.SetValue(left.Value * right.Value);
		return left;
	}
	public static RangedInt operator *(RangedInt left, int right)
	{
		left.SetValue(left.Value * right);
		return left;
	}

	public static bool operator ==(RangedInt left, RangedInt right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(RangedInt left, RangedInt right)
	{
		return !left.Equals(right);
	}
	public static bool operator ==(RangedInt left, int right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(RangedInt left, int right)
	{
		return !left.Equals(right);
	}

	public RangedInt(int value, int min = 0, int max = 10)
	{
		this.value = value;
		this.min = min;
		this.max = max;
	}
	public override string ToString()
	{
		return $"{min}~{value}~{max}";
	}

	public override bool Equals(object? obj)
	{
		if (obj is null) return false;
		return obj is RangedInt @int && Equals(@int);
	}

	public bool Equals(RangedInt other)
	{
		return value == other.value &&
			   min == other.min &&
			   max == other.max;
	}

	public override int GetHashCode()
	{
#if NET48
		int hashCode = -281913742;
		hashCode = hashCode * -1521134295 + value.GetHashCode();
		hashCode = hashCode * -1521134295 + min.GetHashCode();
		hashCode = hashCode * -1521134295 + max.GetHashCode();
		return hashCode;
#else
		return HashCode.Combine(value, min, max);
#endif
	}

	public bool Equals(int other)
	{
		return value.Equals(other);
	}
}