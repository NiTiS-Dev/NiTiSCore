// The NiTiS-Dev licenses this file to you under the MIT license.
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace NiTiS.Math;

[DebuggerDisplay($"{{{nameof(ToString)}(),nq}}")]
[StructLayout(LayoutKind.Sequential)]
public readonly struct Vector4D<T> : IEquatable<Vector4D<T>> where T : unmanaged, IEquatable<T>
{
	public readonly T x, y, z, w;
	public Vector4D(T x, T y, T z, T w)
		=> (this.x, this.y, this.z, this.w) = (x, y, z, w);
	public Vector4D(Vector3D<T> vec3, T w)
		=> (this.x, this.y, this.z, this.w) = (vec3.x, vec3.y, vec3.z, w);
	public Vector4D(Vector2D<T> vec2, T z, T w)
		=> (this.x, this.y, this.z, this.w) = (vec2.x, vec2.y, z, w);

	public static Vector4D<T> operator +(Vector4D<T> left, Vector4D<T> right)
		=> Add(left, right);
	public static Vector4D<T> operator -(Vector4D<T> left, Vector4D<T> right)
		=> Sub(left, right);
	public static Vector4D<T> operator +(Vector4D<T> left, T right)
		=> Add(left, new(right, right, right, right));
	public static Vector4D<T> operator -(Vector4D<T> left, T right)
		=> Sub(left, new(right, right, right, right));
	public static Vector4D<T> operator *(Vector4D<T> left, Vector4D<T> right)
		=> Mul(left, right);
	public static Vector4D<T> operator /(Vector4D<T> left, Vector4D<T> right)
		=> Div(left, right);
	public static Vector4D<T> operator *(Vector4D<T> left, T right)
		=> Mul(left, new(right, right, right, right));
	public static Vector4D<T> operator /(Vector4D<T> left, T right)
		=> Div(left, new(right, right, right, right));
	public static bool operator ==(Vector4D<T> left, Vector4D<T> right)
		=> left.Equals(right);
	public static bool operator !=(Vector4D<T> left, Vector4D<T> right)
		=> !left.Equals(right);
	public bool Equals(Vector4D<T> other)
		=> this.x.Equals(other.x)
		&& this.y.Equals(other.y)
		&& this.z.Equals(other.z);
	public override bool Equals(object? other)
		=> other is Vector4D<T> vec && Equals(vec);

	public static Vector4D<T> Add(Vector4D<T> left, Vector4D<T> right)
		=> new(
			GenericCalculator<T, T, T>.Addition(left.x, right.x),
			GenericCalculator<T, T, T>.Addition(left.y, right.y),
			GenericCalculator<T, T, T>.Addition(left.z, right.z),
			GenericCalculator<T, T, T>.Addition(left.w, right.w)
			);
	public static Vector4D<T> Sub(Vector4D<T> left, Vector4D<T> right)
		=> new(
			GenericCalculator<T, T, T>.Substract(left.x, right.x),
			GenericCalculator<T, T, T>.Substract(left.y, right.y),
			GenericCalculator<T, T, T>.Substract(left.z, right.z),
			GenericCalculator<T, T, T>.Substract(left.w, right.w)
			);
	public static Vector4D<T> Mul(Vector4D<T> left, Vector4D<T> right)
		=> new(
			GenericCalculator<T, T, T>.Multiply(left.x, right.x),
			GenericCalculator<T, T, T>.Multiply(left.y, right.y),
			GenericCalculator<T, T, T>.Multiply(left.z, right.z),
			GenericCalculator<T, T, T>.Multiply(left.w, right.w)
			);
	public static Vector4D<T> Div(Vector4D<T> left, Vector4D<T> right)
		=> new(
			GenericCalculator<T, T, T>.Divide(left.x, right.x),
			GenericCalculator<T, T, T>.Divide(left.y, right.y),
			GenericCalculator<T, T, T>.Divide(left.z, right.z),
			GenericCalculator<T, T, T>.Divide(left.w, right.w)
			);

	public override int GetHashCode()
#if NET48
	{
		int hashCode = 1502939027;
		hashCode = hashCode * -1521134295 + this.x.GetHashCode();
		hashCode = hashCode * -1521134295 + this.y.GetHashCode();
		hashCode = hashCode * -1521134295 + this.z.GetHashCode();
		hashCode = hashCode * -1521134295 + this.w.GetHashCode();
		return hashCode;
	}
#else
		=> HashCode.Combine(x, y, z, w);
#endif
	public override string ToString()
		=> $"{{{x}, {y}, {z}, {w}}}";
}