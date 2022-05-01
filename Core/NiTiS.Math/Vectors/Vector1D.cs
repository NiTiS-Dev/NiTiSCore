using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using static System.Math;

namespace NiTiS.Math.Vectors;


[Serializable]
[DebuggerDisplay("1DFloat ({X})")]
public readonly struct Vector1D :
	IVector<float>,
	ISerializable,
	IEquatable<Vector1D>,
	IEquatable<Vector1DInt>
{
	/// <summary>
	/// First dimension value
	/// </summary>
	public readonly float x;

	public float GetValueByDimension(Axis axis)
	{
		if (axis == Axis.X) { return this.x; } else { return 0; }
	}
	public Vector1D(float x = 0)
	{
		this.x = x;
	}
	public static Vector1D operator +(Vector1D a) => a;
	public static Vector1D operator ++(Vector1D a) => new(a.x + 1);
	public static Vector1D operator -(Vector1D a) => new(-a.x);
	public static Vector1D operator --(Vector1D a) => new(a.x - 1);
	public static Vector1D operator +(Vector1D a, Vector1D b) => new(a.x + b.x);
	public static Vector1D operator -(Vector1D a, Vector1D b) => new(a.x - b.x);
	public static Vector1D operator *(Vector1D a, Vector1D b) => new(a.x * b.x);
	public static Vector1D operator *(Vector1D a, float b) => new(a.x * b);
	public static Vector1D operator /(Vector1D a, Vector1D b) => new(a.x / b.x);
	public static Vector1D operator /(Vector1D a, float b) => new(a.x / b);
	public static bool operator ==(Vector1D lhs, Vector1D rhs) => lhs.Equals(rhs);
	public static bool operator !=(Vector1D lhs, Vector1D rhs) => !lhs.Equals(rhs);
	public static bool operator ==(Vector1D lhs, Vector1DInt rhs) => lhs.Equals(rhs);
	public static bool operator !=(Vector1D lhs, Vector1DInt rhs) => !lhs.Equals(rhs);
	public Vector1DInt VectorInt => new((int)this.x);

	#region Transforms
	public static explicit operator Vector4D(Vector1D b) => new Vector4D(b.x, 0, 0, 0);
	public static explicit operator Vector4DInt(Vector1D b) => new Vector4DInt((int)b.x, 0, 0, 0);
	public static explicit operator Vector3D(Vector1D b) => new Vector3D(b.x, 0, 0);
	public static explicit operator Vector3DInt(Vector1D b) => new Vector3DInt((int)b.x, 0, 0);
	public static explicit operator Vector2D(Vector1D b) => new Vector2D(b.x, 0);
	public static explicit operator Vector2DInt(Vector1D b) => new Vector2DInt((int)b.x, 0);
	public static implicit operator Vector1DInt(Vector1D b) => new Vector1DInt((int)b.x);
	#endregion

	public double LengthSquared => this.x * this.x;
	public double Length => Abs(this.x);
	public Vector1D Normalize() => new(VectorMath.Normalize(x));

	public override string ToString() => "{" + this.x + "}";
	public void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue("x", this.x);
	}
	private Vector1D(SerializationInfo info, StreamingContext context)
	{
		this.x = info.GetSingle("x");
	}
	public bool Equals(Vector1DInt other)
	{
		if (other.x != this.x) { return false; }
		return true;
	}

	public bool Equals(Vector1D other)
	{
		if (other.x != this.x) { return false; }
		return true;
	}

	public override int GetHashCode() => -1830369473 + this.x.GetHashCode();

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