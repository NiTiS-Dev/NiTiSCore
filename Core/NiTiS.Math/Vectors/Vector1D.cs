using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using static System.Math;

namespace NiTiS.Math.Vectors;


[Serializable]
[DebuggerDisplay("1DFloat ({X})")]
public struct Vector1D :
    IVector<float>,
    ISerializable,
    IEquatable<Vector1D>,
    IEquatable<Vector1DInt>
{
    public float X;

    public float GetValueByDimension(Axis axis)
    {
        if (axis == Axis.X) { return X; } else { return 0; }
    }
    public Vector1D(float x = 0)
    {
        X = x;
    }
    public static Vector1D operator +(Vector1D a) => a;
    public static Vector1D operator ++(Vector1D a) => new Vector1D(a.X + 1);
    public static Vector1D operator -(Vector1D a) => new Vector1D(-a.X);
    public static Vector1D operator --(Vector1D a) => new Vector1D(a.X - 1);
    public static Vector1D operator +(Vector1D a, Vector1D b) => new Vector1D(a.X + b.X);
    public static Vector1D operator -(Vector1D a, Vector1D b) => new Vector1D(a.X - b.X);
    public static Vector1D operator *(Vector1D a, Vector1D b) => new Vector1D(a.X * b.X);
    public static Vector1D operator *(Vector1D a, float b) => new Vector1D(a.X * b);
    public static Vector1D operator /(Vector1D a, Vector1D b) => new Vector1D(a.X / b.X);
    public static Vector1D operator /(Vector1D a, float b) => new Vector1D(a.X / b);
    public static bool operator ==(Vector1D lhs, Vector1D rhs) => lhs.Equals(rhs);
    public static bool operator !=(Vector1D lhs, Vector1D rhs) => !lhs.Equals(rhs);
    public static bool operator ==(Vector1D lhs, Vector1DInt rhs) => lhs.Equals(rhs);
    public static bool operator !=(Vector1D lhs, Vector1DInt rhs) => !lhs.Equals(rhs);
    public Vector1DInt VectorInt => new Vector1DInt((int)X);

    #region Transforms
    public static explicit operator Vector4D(Vector1D b) => new Vector4D(b.X, 0, 0, 0);
    public static explicit operator Vector4DInt(Vector1D b) => new Vector4DInt((int)b.X, 0, 0, 0);
    public static explicit operator Vector3D(Vector1D b) => new Vector3D(b.X, 0, 0);
    public static explicit operator Vector3DInt(Vector1D b) => new Vector3DInt((int)b.X, 0, 0);
    public static explicit operator Vector2D(Vector1D b) => new Vector2D(b.X, 0);
    public static explicit operator Vector2DInt(Vector1D b) => new Vector2DInt((int)b.X, 0);
    public static implicit operator Vector1DInt(Vector1D b) => new Vector1DInt((int)b.X);
    #endregion

    public double LengthSquared => X * X;
    public double Length => Abs(X);
    public void Normalize()
    {
        if (X == 0) { return; }
        if (X < 0) { X = -1; } else { X = 1; }
    }

    public override string ToString() => "{" + X + "}";
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("x", X);
    }
    public Vector1D(SerializationInfo info, StreamingContext context)
    {
        X = info.GetSingle("x");
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

    public override bool Equals(object obj)
    {
        if (obj is Vector1DInt vec)
        {
            return obj.Equals(vec);
        }
        if (obj is Vector1D vecInt)
        {
            return obj.Equals(vecInt);
        }
        return base.Equals(obj);
    }
}