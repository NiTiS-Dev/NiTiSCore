using System.Diagnostics;

namespace NiTiS.Core.Variables
{
    [DebuggerDisplay("2DFloat ({X}:{Y})")]
    public struct Vector2D : IVector<float>, INiTiSType
    {
        private static NiVersion version = new NiVersion(1, "1.0");
        public NiVersion Version => version;

        public float X;
        public float Y;
        public const int dimensionCount = 2;
        public int GetDimensionCount() => dimensionCount;
        public float GetValueByDimension(char dimension)
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

        public Vector2D(float x = 0, float y = 0)
        {
            X = x;
            Y = y;
        }
        public static Vector2D operator +(Vector2D a) => a;
        public static Vector2D operator -(Vector2D a) => new Vector2D(-a.X,-a.Y);
        public static Vector2D operator +(Vector2D a, Vector2D b) => new Vector2D(a.X + b.X, a.Y + b.Y);
        public static Vector2D operator -(Vector2D a, Vector2D b) => new Vector2D(a.X - b.X, a.Y - b.Y);
        public static Vector2D operator *(Vector2D a, Vector2D b) => new Vector2D(a.X * b.X, a.Y * b.Y);
        public static Vector2D operator /(Vector2D a, Vector2D b) => new Vector2D(a.X / b.X, a.Y / b.Y);
        public Vector2DInt VectorInt => new Vector2DInt((int)X,(int)Y);

        public override string ToString() => "{" + X + ":" + Y + "}";
    }
}
