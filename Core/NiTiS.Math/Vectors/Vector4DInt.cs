using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using static System.Math;

namespace NiTiS.Math.Vectors;

[Serializable]
[DebuggerDisplay("4DInt ({X}:{Y}:{Z}:{W})")]
public struct Vector4DInt :
    IVector<int>,
    ISerializable,
    IEquatable<Vector4DInt>,
    IEquatable<Vector4D>
{
    public int X;
    public int Y;
    public int Z;
    public int W;
    public int GetValueByDimension(Axis axis)
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

    public Vector4DInt(int x, int y, int z, int w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }
    public static Vector4DInt operator +(Vector4DInt a) => a;
    public static Vector4DInt operator ++(Vector4DInt a) => a + new Vector4DInt(1, 1, 1, 1);
    public static Vector4DInt operator -(Vector4DInt a) => new Vector4DInt(-a.X, -a.Y, -a.Z, -a.W);
    public static Vector4DInt operator --(Vector4DInt a) => a - new Vector4DInt(1, 1, 1, 1);
    public static Vector4DInt operator +(Vector4DInt a, Vector4DInt b) => new Vector4DInt(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
    public static Vector4DInt operator -(Vector4DInt a, Vector4DInt b) => new Vector4DInt(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
    public static Vector4DInt operator *(Vector4DInt a, Vector4DInt b) => new Vector4DInt(a.X * b.X, a.Y * b.Y, a.Z * b.Z, a.W * b.W);
    public static Vector4DInt operator *(Vector4DInt a, int b) => new Vector4DInt(a.X * b, a.Y * b, a.Z * b, a.W * b);
    public static Vector4DInt operator /(Vector4DInt a, Vector4DInt b) => new Vector4DInt(a.X / b.X, a.Y / b.Y, a.Z / b.Z, a.W / b.W);
    public static Vector4DInt operator /(Vector4DInt a, int b) => new Vector4DInt(a.X / b, a.Y / b, a.Z / b, a.W / b);
    public static bool operator ==(Vector4DInt lhs, Vector4D rhs) => lhs.Equals(rhs);
    public static bool operator !=(Vector4DInt lhs, Vector4D rhs) => !lhs.Equals(rhs);
    public static bool operator ==(Vector4DInt lhs, Vector4DInt rhs) => lhs.Equals(rhs);
    public static bool operator !=(Vector4DInt lhs, Vector4DInt rhs) => !lhs.Equals(rhs);

    #region Transforms
    public static explicit operator Vector4D(Vector4DInt b) => new Vector4D(b.X, b.Y, b.Z, b.W);
    public static implicit operator Vector3D(Vector4DInt b) => new Vector3D(b.X, b.Y, b.Z);
    public static implicit operator Vector3DInt(Vector4DInt b) => new Vector3DInt(b.X, b.Y, b.Z);
    public static implicit operator Vector2D(Vector4DInt b) => new Vector2D(b.X, b.Y);
    public static implicit operator Vector2DInt(Vector4DInt b) => new Vector2DInt(b.X, b.Y);
    public static implicit operator Vector1D(Vector4DInt b) => new Vector1D(b.X);
    public static implicit operator Vector1DInt(Vector4DInt b) => new Vector1DInt(b.X);
    #endregion
    public double LengthSquared => (X * X) + (Y * Y) + (Z * Z) + (W * W);
    public double Length => Sqrt(LengthSquared);
    public void Normalize()
    {
        this /= (int)Length;
    }
    public override string ToString() => "{" + X + ":" + Y + ":" + Z + ":" + W + "}";
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("x", X);
        info.AddValue("y", Y);
        info.AddValue("z", Z);
        info.AddValue("w", W);
    }
    public Vector4DInt(SerializationInfo info, StreamingContext context)
    {
        X = info.GetInt32("x");
        Y = info.GetInt32("y");
        Z = info.GetInt32("z");
        W = info.GetInt32("w");
    }

    public bool Equals(Vector4DInt other)
    {
        if (other.X != X) { return false; }
        if (other.Y != Y) { return false; }
        if (other.Z != Z) { return false; }
        if (other.W != W) { return false; }
        return true;
    }

    public bool Equals(Vector4D other)
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
