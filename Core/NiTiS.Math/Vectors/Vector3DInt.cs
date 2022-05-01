using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using static System.Math;

namespace NiTiS.Math.Vectors;

[Serializable]
[DebuggerDisplay("3DInt ({x}:{y}:{z})")]
public readonly struct Vector3DInt :
	IVector<int>,
	ISerializable,
	IEquatable<Vector3DInt>,
	IEquatable<Vector3D>
{
	/// <summary>
	/// First dimension value
	/// </summary>
	public readonly int x;
	/// <summary>
	/// Second dimension value
	/// </summary>
	public readonly int y;
	/// <summary>
	/// Third dimension value
	/// </summary>
	public readonly int z;
	public int GetValueByDimension(Axis axis)
	{
		switch (axis)
		{
			case Axis.X: return x;
			case Axis.Y: return y;
			case Axis.Z: return z;
			default: return 0;
		}
	}

	public Vector3DInt(int x = 0, int y = 0, int z = 0)
	{
		this.x = x;
		this.y = y;
		this.z = z;
	}
	public static Vector3DInt operator +(Vector3DInt a) => a;
	public static Vector3DInt operator ++(Vector3DInt a) => a + new Vector3DInt(1, 1, 1);
	public static Vector3DInt operator -(Vector3DInt a) => new Vector3DInt(-a.x, -a.y, -a.z);
	public static Vector3DInt operator --(Vector3DInt a) => a - new Vector3DInt(1, 1, 1);
	public static Vector3DInt operator +(Vector3DInt a, Vector3DInt b) => new Vector3DInt(a.x + b.x, a.y + b.y, a.z + b.z);
	public static Vector3DInt operator -(Vector3DInt a, Vector3DInt b) => new Vector3DInt(a.x - b.x, a.y - b.y, a.z - b.z);
	public static Vector3DInt operator *(Vector3DInt a, Vector3DInt b) => new Vector3DInt(a.x * b.x, a.y * b.y, a.z * b.z);
	public static Vector3DInt operator *(Vector3DInt a, int b) => new Vector3DInt(a.x * b, a.y * b, a.z * b);
	public static Vector3DInt operator /(Vector3DInt a, Vector3DInt b) => new Vector3DInt(a.x / b.x, a.y / b.y, a.z / b.z);
	public static Vector3DInt operator /(Vector3DInt a, int b) => new Vector3DInt(a.x / b, a.y / b, a.z / b);
	public static bool operator ==(Vector3DInt lhs, Vector3D rhs) => lhs.Equals(rhs);
	public static bool operator !=(Vector3DInt lhs, Vector3D rhs) => !lhs.Equals(rhs);
	public static bool operator ==(Vector3DInt lhs, Vector3DInt rhs) => lhs.Equals(rhs);
	public static bool operator !=(Vector3DInt lhs, Vector3DInt rhs) => !lhs.Equals(rhs);

	#region Transforms
	public static explicit operator Vector4D(Vector3DInt b) => new Vector4D(b.x, b.y, b.z, 0);
	public static explicit operator Vector4DInt(Vector3DInt b) => new Vector4DInt(b.x, b.y, b.z, 0);
	public static implicit operator Vector3D(Vector3DInt b) => new Vector3D(b.x, b.y, b.z);
	public static implicit operator Vector2D(Vector3DInt b) => new Vector2D(b.x, b.y);
	public static implicit operator Vector2DInt(Vector3DInt b) => new Vector2DInt(b.x, b.y);
	public static implicit operator Vector1D(Vector3DInt b) => new Vector1D(b.x);
	public static implicit operator Vector1DInt(Vector3DInt b) => new Vector1DInt(b.x);
	#endregion
	public double LengthSquared => (x * x) + (y * y) + (z * z);
	public double Length => Sqrt(LengthSquared);
	[Obsolete("If you want to normalize vector, try use float-point equivalent")]
	public Vector3DInt Normalize()
	{
		return this / (int)Length;
	}
	public override string ToString() => "{" + x + ":" + y + ":" + z + "}";
	public void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue("x", x);
		info.AddValue("y", y);
		info.AddValue("z", z);
	}
	private Vector3DInt(SerializationInfo info, StreamingContext context)
	{
		x = info.GetInt32("x");
		y = info.GetInt32("y");
		z = info.GetInt32("z");
	}

	public bool Equals(Vector3DInt other)
	{
		if (other.x != x) { return false; }
		if (other.y != y) { return false; }
		if (other.z != z) { return false; }
		return true;
	}

	public bool Equals(Vector3D other)
	{
		if (other.x != x) { return false; }
		if (other.y != y) { return false; }
		if (other.z != z) { return false; }
		return true;
	}

	public override int GetHashCode()
	{
#if NET48
		int hashCode = -307843816;
		hashCode = hashCode * -1521134295 + x.GetHashCode();
		hashCode = hashCode * -1521134295 + y.GetHashCode();
		hashCode = hashCode * -1521134295 + z.GetHashCode();
		return hashCode;
#else
		return HashCode.Combine(this.x, this.y, this.z);
#endif
	}
	public override bool Equals(object? obj)
	{
		if (obj is null) return false;
		if (obj is Vector3DInt vec)
		{
			return this.Equals(vec);
		}
		if (obj is Vector3D vecInt)
		{
			return this.Equals(vecInt);
		}
		return base.Equals(obj);
	}
}
