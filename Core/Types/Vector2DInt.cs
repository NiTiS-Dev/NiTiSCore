using NiTiS.Core.Attributes;
using NiTiS.Core.Enums;
using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using static System.Math;

namespace NiTiS.Core.Types
{
    [Serializable]
    [DebuggerDisplay("2DInt ({X}:{Y})")]
    [NiTiSCoreTypeInfo("1.0.0.0", "2.0.0.0")]
    public struct Vector2DInt : IVector<int>, ISerializable, IEquatable<Vector2DInt>, IEquatable<Vector2D>
    {
        public int X;
        public int Y;

        public int GetValueByDimension(DimensionAxis axis)
        {
            switch (axis)
            {
                case DimensionAxis.X: return X;
                case DimensionAxis.Y: return Y;
                default: return 0;
            }
        }
        public Vector2DInt(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }
        public static Vector2DInt operator +(Vector2DInt a) => a;
        public static Vector2DInt operator ++(Vector2DInt a) => a + new Vector2DInt(1,1);
        public static Vector2DInt operator -(Vector2DInt a) => new Vector2DInt(-a.X,-a.Y);
        public static Vector2DInt operator --(Vector2DInt a) => a - new Vector2DInt(1,1);
        public static Vector2DInt operator +(Vector2DInt a, Vector2DInt b) => new Vector2DInt(a.X + b.X, a.Y + b.Y);
        public static Vector2DInt operator -(Vector2DInt a, Vector2DInt b) => new Vector2DInt(a.X - b.X, a.Y - b.Y);
        public static Vector2DInt operator *(Vector2DInt a, Vector2DInt b) => new Vector2DInt(a.X * b.X, a.Y * b.Y);
        public static Vector2DInt operator *(Vector2DInt a, int b) => new Vector2D(a.X * b, a.Y * b);
        public static Vector2DInt operator /(Vector2DInt a, Vector2DInt b) => new Vector2DInt(a.X / b.X, a.Y / b.Y);
        public static Vector2DInt operator /(Vector2DInt a, int b) => new Vector2D(a.X / b, a.Y / b);
        public static bool operator ==(Vector2DInt lhs, Vector2D rhs) => lhs.Equals(rhs);
        public static bool operator !=(Vector2DInt lhs, Vector2D rhs) => !lhs.Equals(rhs);
        public static bool operator ==(Vector2DInt lhs, Vector2DInt rhs) => lhs.Equals(rhs);
        public static bool operator !=(Vector2DInt lhs, Vector2DInt rhs) => !lhs.Equals(rhs);

        #region Transforms
        public static explicit operator Vector4D(Vector2DInt b) => new Vector4D(b.X, b.Y, 0, 0);
        public static explicit operator Vector4DInt(Vector2DInt b) => new Vector4DInt(b.X, b.Y, 0, 0);
        public static explicit operator Vector3D(Vector2DInt b) => new Vector3D(b.X, b.Y, 0);
        public static explicit operator Vector3DInt(Vector2DInt b) => new Vector3DInt(b.X, b.Y, 0);
        public static implicit operator Vector2D(Vector2DInt b) => new Vector2DInt(b.X, b.Y);
        public static implicit operator Vector1D(Vector2DInt b) => new Vector1D(b.X);
        public static implicit operator Vector1DInt(Vector2DInt b) => new Vector1DInt(b.X);
        #endregion
        public double LengthSquared => (X * X) + (Y * Y);
        public double Length => Sqrt(LengthSquared);
        public void Normalize()
        {
            this /= (int)Length;
        }
        public override string ToString() => "{" + X + ":" + Y + "}";
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("x", X);
            info.AddValue("y", Y);
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
        public override bool Equals(object obj)
        {
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
        public Vector2DInt(SerializationInfo info, StreamingContext context)
        {
            X = info.GetInt32("x");
            Y = info.GetInt32("y");
        }
    }
}
