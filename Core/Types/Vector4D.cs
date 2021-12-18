using NiTiS.Core.Enums;
using System.Diagnostics;
using static System.Math;

namespace NiTiS.Core.Types
{
    [DebuggerDisplay("4DFloat ({X}:{Y}:{Z}:{W})")]
    public struct Vector4D : IVector<float>
    {
        public float X;
        public float Y;
        public float Z;
        public float W;
        public float GetValueByDimension(DimensionAxis axis)
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

        public Vector4D(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }
        public static Vector4D operator +(Vector4D a) => a;
        public static Vector4D operator ++(Vector4D a) => a + new Vector4D(1,1,1,1);
        public static Vector4D operator -(Vector4D a) => new Vector4D(-a.X, -a.Y, -a.Z, -a.W);
        public static Vector4D operator --(Vector4D a) => a - new Vector4D(1,1,1,1);
        public static Vector4D operator +(Vector4D a, Vector4D b) => new Vector4D(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
        public static Vector4D operator -(Vector4D a, Vector4D b) => new Vector4D(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
        public static Vector4D operator *(Vector4D a, Vector4D b) => new Vector4D(a.X * b.X, a.Y * b.Y, a.Z * b.Z, a.W * b.W);
        public static Vector4D operator *(Vector4D a, float b) => new Vector4D(a.X * b, a.Y * b, a.Z * b, a.W * b);
        public static Vector4D operator /(Vector4D a, Vector4D b) => new Vector4D(a.X / b.X, a.Y / b.Y, a.Z / b.Z, a.W / b.W);
        public static Vector4D operator /(Vector4D a, float b) => new Vector4D(a.X / b, a.Y / b, a.Z / b, a.W / b);

        #region Transforms
        public static implicit operator Vector3D(Vector4D b) => new Vector3D(b.X, b.Y, b.Z);
        public static implicit operator Vector3DInt(Vector4D b) => new Vector3DInt((int)b.X, (int)b.Y, (int)b.Z);
        public static implicit operator Vector2D(Vector4D b) => new Vector2D(b.X,b.Y);
        public static implicit operator Vector2DInt(Vector4D b) => new Vector2DInt( (int)b.X, (int)b.Y);
        public static implicit operator Vector1D(Vector4D b) => new Vector1D(b.X);
        public static implicit operator Vector1DInt(Vector4D b) => new Vector1DInt( (int)b.X);
        #endregion
        public double LengthSquared => (X * X) + (Y * Y) + (Z * Z) + (W * W);
        public double Length => Sqrt(LengthSquared);
        public void Normalize()
        {
            this /= (float)Length;
        }
        public override string ToString() => "{" + X + ":" + Y + ":" + Z + ":" + W + "}";
    }
}
