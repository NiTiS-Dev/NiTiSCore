using System;

namespace NiTiS.Math.Experemental.Vectors;

public struct Vector2D<T> where T : struct, IComparable<T>, IEquatable<T>
{
	public T x, y;
	public static Vector2D<T> operator +(Vector2D<T> left, Vector2D<T> right)
	{
		return new(
			(dynamic)left.x + (dynamic)right.x,
			(dynamic)left.y + (dynamic)right.y
			);
	}
	public Vector2D(T x, T y)
	{
		this.y = y;
		this.x = x;
	}

	public override string ToString()
	{
		return $"[{x}, {y}]";
	}
}
