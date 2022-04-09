using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using static System.Math;

namespace NiTiS.Math.Vectors;

[Serializable]
[DebuggerDisplay("1DInt ({X})")]
public struct Vector1DInt :
	IVector<int>,
	ISerializable,
	IEquatable<Vector1DInt>,
	IEquatable<Vector1D>
{
	/// <summary>
	/// First dimension value
	/// </summary>
	public int X;
	public int GetValueByDimension(Axis axis)
	{
		if (axis == Axis.X) { return X; } else { return 0; }
	}

	public Vector1DInt(int x = 0)
	{
		X = x;
	}
	public static Vector1DInt operator +(Vector1DInt a) => a;
	public static Vector1DInt operator -(Vector1DInt a) => new Vector1DInt(-a.X);
	public static Vector1DInt operator ++(Vector1DInt a) => new Vector1DInt(a.X + 1);
	public static Vector1DInt operator --(Vector1DInt a) => new Vector1DInt(a.X - 1);
	public static Vector1DInt operator +(Vector1DInt a, Vector1DInt b) => new Vector1DInt(a.X + b.X);
	public static Vector1DInt operator -(Vector1DInt a, Vector1DInt b) => new Vector1DInt(a.X - b.X);
	public static Vector1DInt operator *(Vector1DInt a, Vector1DInt b) => new Vector1DInt(a.X * b.X);
	public static Vector1DInt operator *(Vector1DInt a, int b) => new Vector1DInt(a.X * b);
	public static Vector1DInt operator /(Vector1DInt a, Vector1DInt b) => new Vector1DInt(a.X / b.X);
	public static Vector1DInt operator /(Vector1DInt a, int b) => new Vector1DInt(a.X / b);
	public static bool operator ==(Vector1DInt lhs, Vector1D rhs) => lhs.Equals(rhs);
	public static bool operator !=(Vector1DInt lhs, Vector1D rhs) => !lhs.Equals(rhs);
	public static bool operator ==(Vector1DInt lhs, Vector1DInt rhs) => lhs.Equals(rhs);
	public static bool operator !=(Vector1DInt lhs, Vector1DInt rhs) => !lhs.Equals(rhs);

	#region Transforms
	public static explicit operator Vector4D(Vector1DInt b) => new Vector4D(b.X, 0, 0, 0);
	public static explicit operator Vector4DInt(Vector1DInt b) => new Vector4DInt(b.X, 0, 0, 0);
	public static explicit operator Vector3D(Vector1DInt b) => new Vector3D(b.X, 0, 0);
	public static explicit operator Vector3DInt(Vector1DInt b) => new Vector3DInt(b.X, 0, 0);
	public static explicit operator Vector2D(Vector1DInt b) => new Vector2D(b.X, 0);
	public static explicit operator Vector2DInt(Vector1DInt b) => new Vector2DInt(b.X, 0);
	public static implicit operator Vector1D(Vector1DInt b) => new Vector1D(b.X);
	#endregion

	public override string ToString() => "{" + X + "}";

	public double LengthSquared => X * X;
	public double Length => Abs(X);
	public void Normalize()
	{
		if (X == 0) { return; }
		if (X < 0) { X = -1; } else { X = 1; }
	}
	public void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue("x", X);
	}
	public Vector1DInt(SerializationInfo info, StreamingContext context)
	{
		X = info.GetInt32("x");
	}
	public bool Equals(Vector1DInt other)
	{
		if (other.X != X) { return false; }
		return true;
	}

	public bool Equals(Vector1D other)
	{
		if (other.X != X) { return false; }
		return true;
	}

	public override int GetHashCode()
	{
		return -1830369473 + X.GetHashCode();
	}
	public override bool Equals(object? obj)
	{
		if (obj is null) return false;
		if (obj is Vector1DInt vec)
		{
			return this.Equals(vec);
		}
		if (obj is Vector1D vecInt)
		{
			return this.Equals(vecInt);
		}
		return base.Equals(obj);
	}
}
