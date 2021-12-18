using NiTiS.Core.Enums;
using System.Diagnostics;
using static System.Math;

namespace NiTiS.Core.Types
{
    [DebuggerDisplay("4DInt ({X}:{Y}:{Z}:{W})")]
    public struct Vector4DInt : IVector<int>
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
        public static Vector4DInt operator ++(Vector4DInt a) => a + new Vector4DInt(1,1,1,1);
        public static Vector4DInt operator -(Vector4DInt a) => new Vector4DInt(-a.X, -a.Y, -a.Z, -a.W);
        public static Vector4DInt operator --(Vector4DInt a) => a - new Vector4DInt(1,1,1,1);
        public static Vector4DInt operator +(Vector4DInt a, Vector4DInt b) => new Vector4DInt(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
        public static Vector4DInt operator -(Vector4DInt a, Vector4DInt b) => new Vector4DInt(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
        public static Vector4DInt operator *(Vector4DInt a, Vector4DInt b) => new Vector4DInt(a.X * b.X, a.Y * b.Y, a.Z * b.Z, a.W * b.W);
        public static Vector4DInt operator *(Vector4DInt a, int b) => new Vector4DInt(a.X * b, a.Y * b, a.Z * b, a.W * b);
        public static Vector4DInt operator /(Vector4DInt a, Vector4DInt b) => new Vector4DInt(a.X / b.X, a.Y / b.Y, a.Z / b.Z, a.W / b.W);
        public static Vector4DInt operator /(Vector4DInt a, int b) => new Vector4DInt(a.X / b, a.Y / b, a.Z / b, a.W / b);

        #region Transforms
        public static implicit operator Vector3D(Vector4DInt b) => new Vector3D(b.X, b.Y, b.Z);
        public static implicit operator Vector3DInt(Vector4DInt b) => new Vector3DInt((int)b.X, (int)b.Y, (int)b.Z);
        public static implicit operator Vector2D(Vector4DInt b) => new Vector2D(b.X,b.Y);
        public static implicit operator Vector2DInt(Vector4DInt b) => new Vector2DInt( (int)b.X, (int)b.Y);
        public static implicit operator Vector1D(Vector4DInt b) => new Vector1D(b.X);
        public static implicit operator Vector1DInt(Vector4DInt b) => new Vector1DInt( (int)b.X);
        #endregion
        public double LengthSquared => (X * X) + (Y * Y) + (Z * Z) + (W * W);
        public double Length => Sqrt(LengthSquared);
        public void Normalize()
        {
            this /= (int)Length;
        }
        public override string ToString() => "{" + X + ":" + Y + ":" + Z + ":" + W + "}";
    }
}
