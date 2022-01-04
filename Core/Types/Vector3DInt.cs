using NiTiS.Core.Enums;
using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using static System.Math;

namespace NiTiS.Core.Types
{
    [Serializable]
    [DebuggerDisplay("3DInt ({X}:{Y}:{Z})")]
    public struct Vector3DInt : IVector<int>, ISerializable, IEquatable<Vector3DInt>, IEquatable<Vector3D>
    {
        public int X;
        public int Y;
        public int Z;
        public int GetValueByDimension(DimensionAxis axis)
        {
            switch (axis)
            {
                case DimensionAxis.X: return X;
                case DimensionAxis.Y: return Y;
                case DimensionAxis.Z: return Z;
                default: return 0;
            }
        }

        public Vector3DInt(int x = 0, int y = 0, int z = 0)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public static Vector3DInt operator +(Vector3DInt a) => a;
        public static Vector3DInt operator ++(Vector3DInt a) => a + new Vector3DInt(1, 1, 1);
        public static Vector3DInt operator -(Vector3DInt a) => new Vector3DInt(-a.X, -a.Y, -a.Z);
        public static Vector3DInt operator --(Vector3DInt a) => a - new Vector3DInt(1, 1, 1);
        public static Vector3DInt operator +(Vector3DInt a, Vector3DInt b) => new Vector3DInt(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        public static Vector3DInt operator -(Vector3DInt a, Vector3DInt b) => new Vector3DInt(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        public static Vector3DInt operator *(Vector3DInt a, Vector3DInt b) => new Vector3DInt(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
        public static Vector3DInt operator *(Vector3DInt a, int b) => new Vector3DInt(a.X * b, a.Y * b, a.Z * b);
        public static Vector3DInt operator /(Vector3DInt a, Vector3DInt b) => new Vector3DInt(a.X / b.X, a.Y / b.Y, a.Z / b.Z);
        public static Vector3DInt operator /(Vector3DInt a, int b) => new Vector3DInt(a.X / b, a.Y / b, a.Z / b);
        public static bool operator ==(Vector3DInt lhs, Vector3D rhs) => lhs.Equals(rhs);
        public static bool operator !=(Vector3DInt lhs, Vector3D rhs) => !lhs.Equals(rhs);
        public static bool operator ==(Vector3DInt lhs, Vector3DInt rhs) => lhs.Equals(rhs);
        public static bool operator !=(Vector3DInt lhs, Vector3DInt rhs) => !lhs.Equals(rhs);

        #region Transforms
        public static explicit operator Vector4D(Vector3DInt b) => new Vector4D(b.X, b.Y, b.Z, 0);
        public static explicit operator Vector4DInt(Vector3DInt b) => new Vector4DInt(b.X, b.Y, b.Z, 0);
        public static implicit operator Vector3D(Vector3DInt b) => new Vector3D(b.X, b.Y, b.Z);
        public static implicit operator Vector2D(Vector3DInt b) => new Vector2D(b.X, b.Y);
        public static implicit operator Vector2DInt(Vector3DInt b) => new Vector2DInt(b.X, b.Y);
        public static implicit operator Vector1D(Vector3DInt b) => new Vector1D(b.X);
        public static implicit operator Vector1DInt(Vector3DInt b) => new Vector1DInt(b.X);
        #endregion
        public double LengthSquared => (X * X) + (Y * Y) + (Z * Z);
        public double Length => Sqrt(LengthSquared);
        public void Normalize()
        {
            this /= (int)Length;
        }
        public override string ToString() => "{" + X + ":" + Y + ":" + Z + "}";
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("x", X);
            info.AddValue("y", Y);
            info.AddValue("z", Z);
        }

        public bool Equals(Vector3DInt other)
        {
            if (other.X != X) { return false; }
            if (other.Y != Y) { return false; }
            if (other.Z != Z) { return false; }
            return true;
        }

        public bool Equals(Vector3D other)
        {
            if (other.X != X) { return false; }
            if (other.Y != Y) { return false; }
            if (other.Z != Z) { return false; }
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = -307843816;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            hashCode = hashCode * -1521134295 + Z.GetHashCode();
            return hashCode;
        }
        public override bool Equals(object obj)
        {
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

        public Vector3DInt(SerializationInfo info, StreamingContext context)
        {
            X = info.GetInt32("x");
            Y = info.GetInt32("y");
            Z = info.GetInt32("z");
        }
    }
}
