using NiTiS.Core.Enums;
using System.Diagnostics;
using static System.Math;

namespace NiTiS.Core.Types
{
    [DebuggerDisplay("2DFloat ({X}:{Y})")]
    public struct Vector2D : IVector<float>
    {
        public float X;
        public float Y;
        public float GetValueByDimension(DimensionAxis axis)
        {
            switch (axis)
            {
                case DimensionAxis.X: return X;
                case DimensionAxis.Y: return Y;
                default: return 0;
            }
        }

        public Vector2D(float x = 0, float y = 0)
        {
            X = x;
            Y = y;
        }
        public static Vector2D operator +(Vector2D a) => a;
        public static Vector2D operator ++(Vector2D a) => a + new Vector2D(1,1);
        public static Vector2D operator -(Vector2D a) => new Vector2D(-a.X,-a.Y);
        public static Vector2D operator --(Vector2D a) => a - new Vector2D(1,1);
        public static Vector2D operator +(Vector2D a, Vector2D b) => new Vector2D(a.X + b.X, a.Y + b.Y);
        public static Vector2D operator -(Vector2D a, Vector2D b) => new Vector2D(a.X - b.X, a.Y - b.Y);
        public static Vector2D operator *(Vector2D a, Vector2D b) => new Vector2D(a.X * b.X, a.Y * b.Y);
        public static Vector2D operator *(Vector2D a, float b) => new Vector2D(a.X * b, a.Y * b);
        public static Vector2D operator /(Vector2D a, Vector2D b) => new Vector2D(a.X / b.X, a.Y / b.Y);
        public static Vector2D operator /(Vector2D a, float b) => new Vector2D(a.X / b, a.Y / b);

        #region Transforms
        public static explicit operator Vector3D(Vector2D b) => new Vector3D(b.X, b.Y, 0);
        public static explicit operator Vector3DInt(Vector2D b) => new Vector3DInt( (int)b.X, (int)b.Y, 0);
        public static implicit operator Vector2DInt(Vector2D b) => new Vector2DInt( (int)b.X, (int)b.Y);
        public static implicit operator Vector1D(Vector2D b) => new Vector1D(b.X);
        public static implicit operator Vector1DInt(Vector2D b) => new Vector1DInt( (int)b.X);
        #endregion

        public double LengthSquared => (X * X) + (Y * Y);
        public double Length => Sqrt(LengthSquared);
        public void Normalize()
        {
            this /= (float)Length;
        }
        public override string ToString() => "{" + X + ":" + Y + "}";
    }
}
