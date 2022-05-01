using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using static System.Math;

namespace NiTiS.Math.Vectors;

[Serializable]
[DebuggerDisplay("2DFloat ({X}:{Y})")]
public readonly struct Vector2D :
	IVector<float>,
	ISerializable,
	IEquatable<Vector2D>,
	IEquatable<Vector2DInt>
{
	/// <summary>
	/// First dimension value
	/// </summary>
	public readonly float x;
	/// <summary>
	/// Second dimension value
	/// </summary>
	public readonly float y;
	public float GetValueByDimension(Axis axis)
	{
		switch (axis)
		{
			case Axis.X: return x;
			case Axis.Y: return y;
			default: return 0;
		}
	}

	public Vector2D(float x = 0, float y = 0)
	{
		this.x = x;
		this.y = y;
	}
	public static Vector2D operator +(Vector2D a) => a;
	public static Vector2D operator ++(Vector2D a) => a + new Vector2D(1, 1);
	public static Vector2D operator -(Vector2D a) => new Vector2D(-a.x, -a.y);
	public static Vector2D operator --(Vector2D a) => a - new Vector2D(1, 1);
	public static Vector2D operator +(Vector2D a, Vector2D b) => new Vector2D(a.x + b.x, a.y + b.y);
	public static Vector2D operator -(Vector2D a, Vector2D b) => new Vector2D(a.x - b.x, a.y - b.y);
	public static Vector2D operator *(Vector2D a, Vector2D b) => new Vector2D(a.x * b.x, a.y * b.y);
	public static Vector2D operator *(Vector2D a, float b) => new Vector2D(a.x * b, a.y * b);
	public static Vector2D operator /(Vector2D a, Vector2D b) => new Vector2D(a.x / b.x, a.y / b.y);
	public static Vector2D operator /(Vector2D a, float b) => new Vector2D(a.x / b, a.y / b);
	public static bool operator ==(Vector2D lhs, Vector2D rhs) => lhs.Equals(rhs);
	public static bool operator !=(Vector2D lhs, Vector2D rhs) => !lhs.Equals(rhs);
	public static bool operator ==(Vector2D lhs, Vector2DInt rhs) => lhs.Equals(rhs);
	public static bool operator !=(Vector2D lhs, Vector2DInt rhs) => !lhs.Equals(rhs);
	public Vector2DInt VectorInt => new Vector2DInt((int)x, (int)y);

	#region Transforms
	public static explicit operator Vector4D(Vector2D b) => new Vector4D(b.x, b.y, 0, 0);
	public static explicit operator Vector4DInt(Vector2D b) => new Vector4DInt((int)b.x, (int)b.y, 0, 0);
	public static explicit operator Vector3D(Vector2D b) => new Vector3D(b.x, b.y, 0);
	public static explicit operator Vector3DInt(Vector2D b) => new Vector3DInt((int)b.x, (int)b.y, 0);
	public static implicit operator Vector2DInt(Vector2D b) => new Vector2DInt((int)b.x, (int)b.y);
	public static implicit operator Vector1D(Vector2D b) => new Vector1D(b.x);
	public static implicit operator Vector1DInt(Vector2D b) => new Vector1DInt((int)b.x);
	#endregion

	public double LengthSquared => (x * x) + (y * y);
	public double Length => Sqrt(LengthSquared);
	public Vector2D Normalize()
	{
		return this / (float)Length;
	}
	public override string ToString() => "{" + x + ":" + y + "}";
	public void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue("x", x);
		info.AddValue("y", y);
	}
	private Vector2D(SerializationInfo info, StreamingContext context)
	{
		x = info.GetSingle("x");
		y = info.GetSingle("y");
	}

	public bool Equals(Vector2D other)
	{
		if (other.x != x) { return false; }
		if (other.y != y) { return false; }
		return true;
	}

	public bool Equals(Vector2DInt other)
	{
		if (other.x != x) { return false; }
		if (other.y != y) { return false; }
		return true;
	}

	public override int GetHashCode()
	{
#if NET48
		int hashCode = 1861411795;
		hashCode = hashCode * -1521134295 + x.GetHashCode();
		hashCode = hashCode * -1521134295 + y.GetHashCode();
		return hashCode;
#else
		return HashCode.Combine(this.x, this.y);
#endif
	}
	public override bool Equals(object? obj)
	{
		if (obj is null) return false;
		if (obj is Vector2DInt vec)
		{
			return this.Equals(vec);
		}
		if (obj is Vector2D vecInt)
		{
			return this.Equals(vecInt);
		}
		return base.Equals(obj);
	}
}
