using NiTiS.Core.Enums;
using System.Diagnostics;
using static System.Math;

namespace NiTiS.Core.Types
{
    [DebuggerDisplay("2DInt ({X}:{Y})")]
    public struct Vector2DInt : IVector<int>
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
    }
}
