﻿using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using static System.Math;

namespace NiTiS.Math.Vectors;

[Serializable]
[DebuggerDisplay("4DFloat ({X}:{Y}:{Z}:{W})")]
public struct Vector4D :
	IVector<float>,
	ISerializable,
	IEquatable<Vector4D>,
	IEquatable<Vector4DInt>
{
	/// <summary>
	/// First dimension value
	/// </summary>
	public float X;
	/// <summary>
	/// Second dimension value
	/// </summary>
	public float Y;
	/// <summary>
	/// Third dimension value
	/// </summary>
	public float Z;
	/// <summary>
	/// Four dimension value
	/// </summary>
	public float W;
	public float GetValueByDimension(Axis axis)
	{
		switch (axis)
		{
			case Axis.X: return X;
			case Axis.Y: return Y;
			case Axis.Z: return Z;
			case Axis.W: return W;
			default: return 0;
		}
	}

	public Vector4D(float x, float y, float z, float w)
	{
		X = x;
		Y = y;
		Z = z;
		W = w;
	}
	public static Vector4D operator +(Vector4D a) => a;
	public static Vector4D operator ++(Vector4D a) => a + new Vector4D(1, 1, 1, 1);
	public static Vector4D operator -(Vector4D a) => new Vector4D(-a.X, -a.Y, -a.Z, -a.W);
	public static Vector4D operator --(Vector4D a) => a - new Vector4D(1, 1, 1, 1);
	public static Vector4D operator +(Vector4D a, Vector4D b) => new Vector4D(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
	public static Vector4D operator -(Vector4D a, Vector4D b) => new Vector4D(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
	public static Vector4D operator *(Vector4D a, Vector4D b) => new Vector4D(a.X * b.X, a.Y * b.Y, a.Z * b.Z, a.W * b.W);
	public static Vector4D operator *(Vector4D a, float b) => new Vector4D(a.X * b, a.Y * b, a.Z * b, a.W * b);
	public static Vector4D operator /(Vector4D a, Vector4D b) => new Vector4D(a.X / b.X, a.Y / b.Y, a.Z / b.Z, a.W / b.W);
	public static Vector4D operator /(Vector4D a, float b) => new Vector4D(a.X / b, a.Y / b, a.Z / b, a.W / b);
	public static bool operator ==(Vector4D lhs, Vector4D rhs) => lhs.Equals(rhs);
	public static bool operator !=(Vector4D lhs, Vector4D rhs) => !lhs.Equals(rhs);
	public static bool operator ==(Vector4D lhs, Vector4DInt rhs) => lhs.Equals(rhs);
	public static bool operator !=(Vector4D lhs, Vector4DInt rhs) => !lhs.Equals(rhs);
	public Vector4DInt VectorInt => new Vector4DInt((int)X, (int)Y, (int)X, (int)Z);

	#region Transforms
	public static implicit operator Vector4DInt(Vector4D b) => new Vector4DInt((int)b.X, (int)b.Y, (int)b.Z, (int)b.W);
	public static implicit operator Vector3D(Vector4D b) => new Vector3D(b.X, b.Y, b.Z);
	public static implicit operator Vector3DInt(Vector4D b) => new Vector3DInt((int)b.X, (int)b.Y, (int)b.Z);
	public static implicit operator Vector2D(Vector4D b) => new Vector2D(b.X, b.Y);
	public static implicit operator Vector2DInt(Vector4D b) => new Vector2DInt((int)b.X, (int)b.Y);
	public static implicit operator Vector1D(Vector4D b) => new Vector1D(b.X);
	public static implicit operator Vector1DInt(Vector4D b) => new Vector1DInt((int)b.X);
	#endregion
	public double LengthSquared => (X * X) + (Y * Y) + (Z * Z) + (W * W);
	public double Length => Sqrt(LengthSquared);
	public void Normalize()
	{
		this /= (float)Length;
	}
	public override string ToString() => "{" + X + ":" + Y + ":" + Z + ":" + W + "}";
	public void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue("x", X);
		info.AddValue("y", Y);
		info.AddValue("z", Z);
		info.AddValue("w", W);
	}
	public Vector4D(SerializationInfo info, StreamingContext context)
	{
		X = info.GetSingle("x");
		Y = info.GetSingle("y");
		Z = info.GetSingle("z");
		W = info.GetSingle("w");
	}
	public bool Equals(Vector4D other)
	{
		if (other.X != X) { return false; }
		if (other.Y != Y) { return false; }
		if (other.Z != Z) { return false; }
		if (other.W != W) { return false; }
		return true;
	}

	public bool Equals(Vector4DInt other)
	{
		if (other.X != X) { return false; }
		if (other.Y != Y) { return false; }
		if (other.Z != Z) { return false; }
		if (other.W != W) { return false; }
		return true;
	}

	public override int GetHashCode()
	{
		int hashCode = 707706286;
		hashCode = hashCode * -1521134295 + X.GetHashCode();
		hashCode = hashCode * -1521134295 + Y.GetHashCode();
		hashCode = hashCode * -1521134295 + Z.GetHashCode();
		hashCode = hashCode * -1521134295 + W.GetHashCode();
		return hashCode;
	}
	public override bool Equals(object? obj)
	{
		if (obj is null) return false;
		if (obj is Vector4DInt vec)
		{
			return this.Equals(vec);
		}
		if (obj is Vector4D vecInt)
		{
			return this.Equals(vecInt);
		}
		return base.Equals(obj);
	}
}
