using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using static System.Math;

namespace NiTiS.Math.Vectors;

[Serializable]
[DebuggerDisplay("2DInt ({X}:{Y})")]
public readonly struct Vector2DInt :
	IVector<int>,
	ISerializable,
	IEquatable<Vector2DInt>,
	IEquatable<Vector2D>
{
	/// <summary>
	/// First dimension value
	/// </summary>
	public readonly int x;
	/// <summary>
	/// Second dimension value
	/// </summary>
	public readonly int y;

	public int GetValueByDimension(Axis axis)
	{
		switch (axis)
		{
			case Axis.X: return x;
			case Axis.Y: return y;
			default: return 0;
		}
	}
	public Vector2DInt(int x = 0, int y = 0)
	{
		this.x = x;
		this.y = y;
	}
	public static Vector2DInt operator +(Vector2DInt a) => a;
	public static Vector2DInt operator ++(Vector2DInt a) => a + new Vector2DInt(1, 1);
	public static Vector2DInt operator -(Vector2DInt a) => new Vector2DInt(-a.x, -a.y);
	public static Vector2DInt operator --(Vector2DInt a) => a - new Vector2DInt(1, 1);
	public static Vector2DInt operator +(Vector2DInt a, Vector2DInt b) => new Vector2DInt(a.x + b.x, a.y + b.y);
	public static Vector2DInt operator -(Vector2DInt a, Vector2DInt b) => new Vector2DInt(a.x - b.x, a.y - b.y);
	public static Vector2DInt operator *(Vector2DInt a, Vector2DInt b) => new Vector2DInt(a.x * b.x, a.y * b.y);
	public static Vector2DInt operator *(Vector2DInt a, int b) => new Vector2D(a.x * b, a.y * b);
	public static Vector2DInt operator /(Vector2DInt a, Vector2DInt b) => new Vector2DInt(a.x / b.x, a.y / b.y);
	public static Vector2DInt operator /(Vector2DInt a, int b) => new Vector2D(a.x / b, a.y / b);
	public static bool operator ==(Vector2DInt lhs, Vector2D rhs) => lhs.Equals(rhs);
	public static bool operator !=(Vector2DInt lhs, Vector2D rhs) => !lhs.Equals(rhs);
	public static bool operator ==(Vector2DInt lhs, Vector2DInt rhs) => lhs.Equals(rhs);
	public static bool operator !=(Vector2DInt lhs, Vector2DInt rhs) => !lhs.Equals(rhs);

	#region Transforms
	public static explicit operator Vector4D(Vector2DInt b) => new Vector4D(b.x, b.y, 0, 0);
	public static explicit operator Vector4DInt(Vector2DInt b) => new Vector4DInt(b.x, b.y, 0, 0);
	public static explicit operator Vector3D(Vector2DInt b) => new Vector3D(b.x, b.y, 0);
	public static explicit operator Vector3DInt(Vector2DInt b) => new Vector3DInt(b.x, b.y, 0);
	public static implicit operator Vector2D(Vector2DInt b) => new Vector2DInt(b.x, b.y);
	public static implicit operator Vector1D(Vector2DInt b) => new Vector1D(b.x);
	public static implicit operator Vector1DInt(Vector2DInt b) => new Vector1DInt(b.x);
	#endregion
	public double LengthSquared => (x * x) + (y * y);
	public double Length => Sqrt(LengthSquared);
	[Obsolete("If you want to normalize vector, try use float-point equivalent")]
	public Vector2DInt Normalize()
	{
		return this / (int)Length;
	}
	public override string ToString() => "{" + x + ":" + y + "}";
	public void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue("x", x);
		info.AddValue("y", y);
	}
	private Vector2DInt(SerializationInfo info, StreamingContext context)
	{
		x = info.GetInt32("x");
		y = info.GetInt32("y");
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
