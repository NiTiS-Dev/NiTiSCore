using System.Diagnostics;

namespace NiTiS.Core.Variables
{
    [DebuggerDisplay("2DInt ({X}:{Y})")]
    public struct Vector2DInt : IVector<int>, INiTiSType
    {
        private static NiVersion version = new NiVersion(1, "1.0");
        public NiVersion Version => version;

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
        public Vector2D Vector => new Vector2D(X);

        public override string ToString() => "{" + X + ":" + Y + "}";
    }
}
