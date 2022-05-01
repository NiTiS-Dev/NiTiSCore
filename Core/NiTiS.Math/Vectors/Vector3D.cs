using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using static System.Math;

namespace NiTiS.Math.Vectors;

[Serializable]
[DebuggerDisplay("3DFloat ({x}:{y}:{z})")]
public readonly struct Vector3D :
	IVector<float>,
	ISerializable,
	IEquatable<Vector3D>,
	IEquatable<Vector3DInt>
{
	/// <summary>
	/// First dimension value
	/// </summary>
	public readonly float x;
	/// <summary>
	/// Second dimension value
	/// </summary>
	public readonly float y;
	/// <summary>
	/// Third dimension value
	/// </summary>
	public readonly float z;
	public float GetValueByDimension(Axis axis)
	{
		switch (axis)
		{
			case Axis.X: return x;
			case Axis.Y: return y;
			case Axis.Z: return z;
			default: return 0;
		}
	}

	public Vector3D(float x, float y, float z)
	{
		this.x = x;
		this.y = y;
		this.z = z;
	}
	public static Vector3D operator +(Vector3D a) => a;
	public static Vector3D operator ++(Vector3D a) => a + new Vector3D(1, 1, 1);
	public static Vector3D operator -(Vector3D a) => new Vector3D(-a.x, -a.y, -a.z);
	public static Vector3D operator --(Vector3D a) => a - new Vector3D(1, 1, 1);
	public static Vector3D operator +(Vector3D a, Vector3D b) => new Vector3D(a.x + b.x, a.y + b.y, a.z + b.z);
	public static Vector3D operator -(Vector3D a, Vector3D b) => new Vector3D(a.x - b.x, a.y - b.y, a.z - b.z);
	public static Vector3D operator *(Vector3D a, Vector3D b) => new Vector3D(a.x * b.x, a.y * b.y, a.z * b.z);
	public static Vector3D operator *(Vector3D a, float b) => new Vector3D(a.x * b, a.y * b, a.z * b);
	public static Vector3D operator /(Vector3D a, Vector3D b) => new Vector3D(a.x / b.x, a.y / b.y, a.z / b.z);
	public static Vector3D operator /(Vector3D a, float b) => new Vector3D(a.x / b, a.y / b, a.z / b);
	public static bool operator ==(Vector3D lhs, Vector3D rhs) => lhs.Equals(rhs);
	public static bool operator !=(Vector3D lhs, Vector3D rhs) => !lhs.Equals(rhs);
	public static bool operator ==(Vector3D lhs, Vector3DInt rhs) => lhs.Equals(rhs);
	public static bool operator !=(Vector3D lhs, Vector3DInt rhs) => !lhs.Equals(rhs);
	public Vector3DInt VectorInt => new Vector3DInt((int)x, (int)y, (int)x);

	#region Transforms
	public static explicit operator Vector4D(Vector3D b) => new Vector4D(b.x, b.y, b.z, 0);
	public static explicit operator Vector4DInt(Vector3D b) => new Vector4DInt((int)b.x, (int)b.y, (int)b.z, 0);
	public static implicit operator Vector3DInt(Vector3D b) => new Vector3DInt((int)b.x, (int)b.y, (int)b.z);
	public static implicit operator Vector2D(Vector3D b) => new Vector2D(b.x, b.y);
	public static implicit operator Vector2DInt(Vector3D b) => new Vector2DInt((int)b.x, (int)b.y);
	public static implicit operator Vector1D(Vector3D b) => new Vector1D(b.x);
	public static implicit operator Vector1DInt(Vector3D b) => new Vector1DInt((int)b.x);
	#endregion
	public double LengthSquared => (x * x) + (y * y) + (z * z);
	public double Length => Sqrt(LengthSquared);
	public Vector3D Normalize()
	{
		return this / (float)Length;
	}
	public override string ToString() => "{" + x + ":" + y + ":" + z + "}";
	public void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue("x", x);
		info.AddValue("y", y);
		info.AddValue("z", z);
	}
	private Vector3D(SerializationInfo info, StreamingContext context)
	{
		x = info.GetSingle("x");
		y = info.GetSingle("y");
		z = info.GetSingle("z");
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
