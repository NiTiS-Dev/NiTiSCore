using NiTiS.Core.Attributes;
using NiTiS.Core.Enums;
using System;
using System.Diagnostics;
#if NITIS_SERIALIZATION
using System.Runtime.Serialization;
#endif
using static System.Math;

namespace NiTiS.Core.Types
{
#if NITIS_SERIALIZATION
    [Serializable]
#endif
    [DebuggerDisplay("4DInt ({X}:{Y}:{Z}:{W})")]
    [NiTiSCoreTypeInfo("1.3.0.0", "2.0.0.0")]
    public struct Vector4DInt : 
        IVector<int>,
#if NITIS_SERIALIZATION
        ISerializable, 
#endif
        IEquatable<Vector4DInt>, 
        IEquatable<Vector4D>
    {
        public int X;
        public int Y;
        public int Z;
        public int W;
        public int GetValueByDimension(DimensionAxis axis)
        {
            switch (axis)
            {
                case DimensionAxis.X: return X;
                case DimensionAxis.Y: return Y;
                case DimensionAxis.Z: return Z;
                case DimensionAxis.W: return W;
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
#if NITIS_SERIALIZATION
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
#endif

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
        public override bool Equals(object obj)
        {
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
}
