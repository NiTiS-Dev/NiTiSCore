// The NiTiS-Dev licenses this file to you under the MIT license.
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace NiTiS.Math;

[DebuggerDisplay($"{{{nameof(ToString)}(),nq}}")]
[StructLayout(LayoutKind.Sequential)]
public readonly struct Vector2D<T> : IEquatable<Vector2D<T>> where T : unmanaged, IEquatable<T>
{
	public readonly T x, y;
	public Vector2D(T x, T y)
		=> (this.x, this.y) = (x, y);
	public static Vector2D<T> operator +(Vector2D<T> left, Vector2D<T> right)
		=> Add(left, right);
	public static Vector2D<T> operator -(Vector2D<T> left, Vector2D<T> right)
		=> Sub(left, right);
	public static Vector2D<T> operator +(Vector2D<T> left, T right)
		=> Add(left, new(right, right));
	public static Vector2D<T> operator -(Vector2D<T> left, T right)
		=> Sub(left, new(right, right));
	public static Vector2D<T> operator *(Vector2D<T> left, Vector2D<T> right)
		=> Mul(left, right);
	public static Vector2D<T> operator /(Vector2D<T> left, Vector2D<T> right)
		=> Div(left, right);
	public static Vector2D<T> operator *(Vector2D<T> left, T right)
		=> Mul(left, new(right, right));
	public static Vector2D<T> operator /(Vector2D<T> left, T right)
		=> Div(left, new(right, right));
	public static bool operator ==(Vector2D<T> left, Vector2D<T> right)
		=> left.Equals(right);
	public static bool operator !=(Vector2D<T> left, Vector2D<T> right)
		=> !left.Equals(right);
	public bool Equals(Vector2D<T> other)
		=> this.x.Equals(other.x)
		&& this.y.Equals(other.y);
	public override bool Equals(object? other)
		=> other is Vector2D<T> vec && Equals(vec);

	public static Vector2D<T> Add(Vector2D<T> left, Vector2D<T> right)
		=> new(GenericCalculator<T, T, T>.Addition(left.x, right.x), GenericCalculator<T, T, T>.Addition(left.y, right.y));
	public static Vector2D<T> Sub(Vector2D<T> left, Vector2D<T> right)
		=> new(GenericCalculator<T, T, T>.Substract(left.x, right.x), GenericCalculator<T, T, T>.Substract(left.y, right.y));
	public static Vector2D<T> Mul(Vector2D<T> left, Vector2D<T> right)
		=> new(GenericCalculator<T, T, T>.Multiply(left.x, right.x), GenericCalculator<T, T, T>.Multiply(left.y, right.y));
	public static Vector2D<T> Div(Vector2D<T> left, Vector2D<T> right)
		=> new(GenericCalculator<T, T, T>.Divide(left.x, right.x), GenericCalculator<T, T, T>.Divide(left.y, right.y));

	public override int GetHashCode()
#if NET48
	{
		int hashCode = 1502939027;
		hashCode = hashCode * -1521134295 + this.x.GetHashCode();
		hashCode = hashCode * -1521134295 + this.y.GetHashCode();
		return hashCode;
	}
#else
		=> HashCode.Combine(x, y);
#endif
	public override string ToString()
		=> $"{{{x}, {y}}}";
}
