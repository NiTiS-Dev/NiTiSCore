using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using static System.Math;

namespace NiTiS.Math.Vectors;

[Serializable]
[DebuggerDisplay("4DFloat ({x}:{y}:{z}:{w})")]
public readonly struct Vector4D :
	IVector<float>,
	ISerializable,
	IEquatable<Vector4D>,
	IEquatable<Vector4DInt>
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
	public readonly float z
		;
	/// <summary>
	/// Four dimension value
	/// </summary>
	public readonly float w;
	public float GetValueByDimension(Axis axis)
	{
		switch (axis)
		{
			case Axis.X: return x;
			case Axis.Y: return y;
			case Axis.Z: return z;
			case Axis.W: return w;
			default: return 0;
		}
	}

	public Vector4D(float x, float y, float z, float w)
	{
		this.x = x;
		this.y = y;
		this.z = z;
		this.w = w;
	}
	public static Vector4D operator +(Vector4D a) => a;
	public static Vector4D operator ++(Vector4D a) => a + new Vector4D(1, 1, 1, 1);
	public static Vector4D operator -(Vector4D a) => new Vector4D(-a.x, -a.y, -a.z, -a.w);
	public static Vector4D operator --(Vector4D a) => a - new Vector4D(1, 1, 1, 1);
	public static Vector4D operator +(Vector4D a, Vector4D b) => new Vector4D(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
	public static Vector4D operator -(Vector4D a, Vector4D b) => new Vector4D(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);
	public static Vector4D operator *(Vector4D a, Vector4D b) => new Vector4D(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w);
	public static Vector4D operator *(Vector4D a, float b) => new Vector4D(a.x * b, a.y * b, a.z * b, a.w * b);
	public static Vector4D operator /(Vector4D a, Vector4D b) => new Vector4D(a.x / b.x, a.y / b.y, a.z / b.z, a.w / b.w);
	public static Vector4D operator /(Vector4D a, float b) => new Vector4D(a.x / b, a.y / b, a.z / b, a.w / b);
	public static bool operator ==(Vector4D lhs, Vector4D rhs) => lhs.Equals(rhs);
	public static bool operator !=(Vector4D lhs, Vector4D rhs) => !lhs.Equals(rhs);
	public static bool operator ==(Vector4D lhs, Vector4DInt rhs) => lhs.Equals(rhs);
	public static bool operator !=(Vector4D lhs, Vector4DInt rhs) => !lhs.Equals(rhs);
	public Vector4DInt VectorInt => new Vector4DInt((int)x, (int)y, (int)x, (int)z);

	#region Transforms
	public static implicit operator Vector4DInt(Vector4D b) => new Vector4DInt((int)b.x, (int)b.y, (int)b.z, (int)b.w);
	public static implicit operator Vector3D(Vector4D b) => new Vector3D(b.x, b.y, b.z);
	public static implicit operator Vector3DInt(Vector4D b) => new Vector3DInt((int)b.x, (int)b.y, (int)b.z);
	public static implicit operator Vector2D(Vector4D b) => new Vector2D(b.x, b.y);
	public static implicit operator Vector2DInt(Vector4D b) => new Vector2DInt((int)b.x, (int)b.y);
	public static implicit operator Vector1D(Vector4D b) => new Vector1D(b.x);
	public static implicit operator Vector1DInt(Vector4D b) => new Vector1DInt((int)b.x);
	#endregion
	public double LengthSquared => (x * x) + (y * y) + (z * z) + (w * w);
	public double Length => Sqrt(LengthSquared);
	public Vector4D Normalize()
	{
		return this / (float)Length;
	}
	public override string ToString() => "{" + x + ":" + y + ":" + z + ":" + w + "}";
	public void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue("x", x);
		info.AddValue("y", y);
		info.AddValue("z", z);
		info.AddValue("w", w);
	}
	private Vector4D(SerializationInfo info, StreamingContext context)
	{
		x = info.GetSingle("x");
		y = info.GetSingle("y");
		z = info.GetSingle("z");
		w = info.GetSingle("w");
	}
	public bool Equals(Vector4D other)
	{
		if (other.x != x) { return false; }
		if (other.y != y) { return false; }
		if (other.z != z) { return false; }
		if (other.w != w) { return false; }
		return true;
	}

	public bool Equals(Vector4DInt other)
	{
		if (other.x != x) { return false; }
		if (other.y != y) { return false; }
		if (other.z != z) { return false; }
		if (other.w != w) { return false; }
		return true;
	}

	public override int GetHashCode()
	{
#if NET48
		int hashCode = 707706286;
		hashCode = hashCode * -1521134295 + x.GetHashCode();
		hashCode = hashCode * -1521134295 + y.GetHashCode();
		hashCode = hashCode * -1521134295 + z.GetHashCode();
		hashCode = hashCode * -1521134295 + w.GetHashCode();
		return hashCode;
#else
		return HashCode.Combine(this.x, this.y, this.z, this.w);
#endif
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
