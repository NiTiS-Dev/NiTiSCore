using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using static System.Math;

namespace NiTiS.Math.Vectors;

[Serializable]
[DebuggerDisplay("2DFloat ({X}:{Y})")]
public struct Vector2D :
    IVector<float>,
    ISerializable,
    IEquatable<Vector2D>,
    IEquatable<Vector2DInt>
{
    public float X;
    public float Y;
    public float GetValueByDimension(Axis axis)
    {
        switch (axis)
        {
            case Axis.X: return X;
            case Axis.Y: return Y;
            default: return 0;
        }
    }

    public Vector2D(float x = 0, float y = 0)
    {
        X = x;
        Y = y;
    }
    public static Vector2D operator +(Vector2D a) => a;
    public static Vector2D operator ++(Vector2D a) => a + new Vector2D(1, 1);
    public static Vector2D operator -(Vector2D a) => new Vector2D(-a.X, -a.Y);
    public static Vector2D operator --(Vector2D a) => a - new Vector2D(1, 1);
    public static Vector2D operator +(Vector2D a, Vector2D b) => new Vector2D(a.X + b.X, a.Y + b.Y);
    public static Vector2D operator -(Vector2D a, Vector2D b) => new Vector2D(a.X - b.X, a.Y - b.Y);
    public static Vector2D operator *(Vector2D a, Vector2D b) => new Vector2D(a.X * b.X, a.Y * b.Y);
    public static Vector2D operator *(Vector2D a, float b) => new Vector2D(a.X * b, a.Y * b);
    public static Vector2D operator /(Vector2D a, Vector2D b) => new Vector2D(a.X / b.X, a.Y / b.Y);
    public static Vector2D operator /(Vector2D a, float b) => new Vector2D(a.X / b, a.Y / b);
    public static bool operator ==(Vector2D lhs, Vector2D rhs) => lhs.Equals(rhs);
    public static bool operator !=(Vector2D lhs, Vector2D rhs) => !lhs.Equals(rhs);
    public static bool operator ==(Vector2D lhs, Vector2DInt rhs) => lhs.Equals(rhs);
    public static bool operator !=(Vector2D lhs, Vector2DInt rhs) => !lhs.Equals(rhs);
    public Vector2DInt VectorInt => new Vector2DInt((int)X, (int)Y);

    #region Transforms
    public static explicit operator Vector4D(Vector2D b) => new Vector4D(b.X, b.Y, 0, 0);
    public static explicit operator Vector4DInt(Vector2D b) => new Vector4DInt((int)b.X, (int)b.Y, 0, 0);
    public static explicit operator Vector3D(Vector2D b) => new Vector3D(b.X, b.Y, 0);
    public static explicit operator Vector3DInt(Vector2D b) => new Vector3DInt((int)b.X, (int)b.Y, 0);
    public static implicit operator Vector2DInt(Vector2D b) => new Vector2DInt((int)b.X, (int)b.Y);
    public static implicit operator Vector1D(Vector2D b) => new Vector1D(b.X);
    public static implicit operator Vector1DInt(Vector2D b) => new Vector1DInt((int)b.X);
    #endregion

    public double LengthSquared => (X * X) + (Y * Y);
    public double Length => Sqrt(LengthSquared);
    public void Normalize()
    {
        this /= (float)Length;
    }
    public override string ToString() => "{" + X + ":" + Y + "}";
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("x", X);
        info.AddValue("y", Y);
    }
    public Vector2D(SerializationInfo info, StreamingContext context)
    {
        X = info.GetSingle("x");
        Y = info.GetSingle("y");
    }

    public bool Equals(Vector2D other)
    {
        if (other.X != X) { return false; }
        if (other.Y != Y) { return false; }
        return true;
    }

    public bool Equals(Vector2DInt other)
    {
        if (other.X != X) { return false; }
        if (other.Y != Y) { return false; }
        return true;
    }

    public override int GetHashCode()
    {
        int hashCode = 1861411795;
        hashCode = hashCode * -1521134295 + X.GetHashCode();
        hashCode = hashCode * -1521134295 + Y.GetHashCode();
        return hashCode;
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
