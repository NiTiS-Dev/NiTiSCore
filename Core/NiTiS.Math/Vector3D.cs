// The NiTiS-Dev licenses this file to you under the MIT license.

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace NiTiS.Math;

[DebuggerDisplay($"{{{nameof(ToString)}(),nq}}")]
[StructLayout(LayoutKind.Sequential)]
public readonly struct Vector3D<T> : IEquatable<Vector3D<T>> where T : unmanaged, IEquatable<T>
{
	public readonly T x, y, z;
	public Vector3D(T x, T y, T z)
		=> (this.x, this.y, this.z) = (x, y, z);
	public Vector3D(Vector2D<T> vec2, T z)
		=> (this.x, this.y, this.z) = (vec2.x, vec2.y, z);
	public static Vector3D<T> operator +(Vector3D<T> left, Vector3D<T> right)
		=> Add(left, right);
	public static Vector3D<T> operator -(Vector3D<T> left, Vector3D<T> right)
		=> Sub(left, right);
	public static Vector3D<T> operator +(Vector3D<T> left, T right)
		=> Add(left, new(right, right, right));
	public static Vector3D<T> operator -(Vector3D<T> left, T right)
		=> Sub(left, new(right, right, right));
	public static Vector3D<T> operator *(Vector3D<T> left, Vector3D<T> right)
		=> Mul(left, right);
	public static Vector3D<T> operator /(Vector3D<T> left, Vector3D<T> right)
		=> Div(left, right);
	public static Vector3D<T> operator *(Vector3D<T> left, T right)
		=> Mul(left, new(right, right, right));
	public static Vector3D<T> operator /(Vector3D<T> left, T right)
		=> Div(left, new(right, right, right));
	public static bool operator ==(Vector3D<T> left, Vector3D<T> right)
		=> left.Equals(right);
	public static bool operator !=(Vector3D<T> left, Vector3D<T> right)
		=> !left.Equals(right);
	public bool Equals(Vector3D<T> other)
		=> this.x.Equals(other.x)
		&& this.y.Equals(other.y)
		&& this.z.Equals(other.z);
	public override bool Equals(object? other)
		=> other is Vector3D<T> vec && Equals(vec);

	public static Vector3D<T> Add(Vector3D<T> left, Vector3D<T> right)
		=> new(
			GenericCalculator<T, T, T>.Addition(left.x, right.x),
			GenericCalculator<T, T, T>.Addition(left.y, right.y),
			GenericCalculator<T, T, T>.Addition(left.z, right.z)
			);
	public static Vector3D<T> Sub(Vector3D<T> left, Vector3D<T> right)
		=> new(
			GenericCalculator<T, T, T>.Substract(left.x, right.x),
			GenericCalculator<T, T, T>.Substract(left.y, right.y),
			GenericCalculator<T, T, T>.Substract(left.z, right.z)
			);
	public static Vector3D<T> Mul(Vector3D<T> left, Vector3D<T> right)
		=> new(
			GenericCalculator<T, T, T>.Multiply(left.x, right.x),
			GenericCalculator<T, T, T>.Multiply(left.y, right.y),
			GenericCalculator<T, T, T>.Multiply(left.z, right.z)
			);
	public static Vector3D<T> Div(Vector3D<T> left, Vector3D<T> right)
		=> new(
			GenericCalculator<T, T, T>.Divide(left.x, right.x),
			GenericCalculator<T, T, T>.Divide(left.y, right.y),
			GenericCalculator<T, T, T>.Divide(left.z, right.z)
			);

	public override int GetHashCode()
#if NET48
	{
		int hashCode = 1502939027;
		hashCode = hashCode * -1521134295 + this.x.GetHashCode();
		hashCode = hashCode * -1521134295 + this.y.GetHashCode();
		hashCode = hashCode * -1521134295 + this.z.GetHashCode();
		return hashCode;
	}
#else
		=> HashCode.Combine(x, y, z);
#endif
	public override string ToString()
		=> $"{{{x}, {y}, {z}}}";
}
