using System.Diagnostics;

namespace NiTiS.Core.Variables
{
    [DebuggerDisplay("2DInt ({X}:{Y})")]
    public struct Vector2DInt : IVector<int>
    {
        public int X;
        public int Y;
        public const int dimensionCount = 2;
        public int GetDimensionCount() => dimensionCount;
        public int GetValueByDimension(char dimension)
        {
            if (dimension == 'x' || dimension == 'X')
            {
                return X;
            }
            else if (dimension == 'y' || dimension == 'Y')
            {
                return Y;
            }
            else
            {
                return 0;
            }
        }

        public Vector2DInt(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }
        public static Vector2DInt operator +(Vector2DInt a) => a;
        public static Vector2DInt operator -(Vector2DInt a) => new Vector2DInt(-a.X,-a.Y);
        public static Vector2DInt operator +(Vector2DInt a, Vector2DInt b) => new Vector2DInt(a.X + b.X, a.Y + b.Y);
        public static Vector2DInt operator -(Vector2DInt a, Vector2DInt b) => new Vector2DInt(a.X - b.X, a.Y - b.Y);
        public static Vector2DInt operator *(Vector2DInt a, Vector2DInt b) => new Vector2DInt(a.X * b.X, a.Y * b.Y);
        public static Vector2DInt operator /(Vector2DInt a, Vector2DInt b) => new Vector2DInt(a.X / b.X, a.Y / b.Y);
        
        #region Transforms
        public static explicit operator Vector3D(Vector2DInt b) => new Vector3D(b.X, b.Y, 0);
        public static explicit operator Vector3DInt(Vector2DInt b) => new Vector3DInt(b.X, b.Y, 0);
        public static implicit operator Vector2D(Vector2DInt b) => new Vector2DInt(b.X, b.Y);
        public static implicit operator Vector1D(Vector2DInt b) => new Vector1D(b.X);
        public static implicit operator Vector1DInt(Vector2DInt b) => new Vector1DInt(b.X);
        #endregion
        public override string ToString() => "{" + X + ":" + Y + "}";
    }
}
