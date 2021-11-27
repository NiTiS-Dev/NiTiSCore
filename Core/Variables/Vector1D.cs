using System.Diagnostics;

namespace NiTiS.Core.Variables
{
    [DebuggerDisplay("1DFloat ({X})")]
    public struct Vector1D : IVector<float>
    {
        public float X;
        public const int dimensionCount = 1;
        public int GetDimensionCount() => dimensionCount;

        public float GetValueByDimension(char dimension)
        {
            if(dimension == 'x' || dimension == 'X')
            {
                return X;
            }
            else
            {
                return 0;
            }
        }
        public Vector1D(float x = 0)
        {
            X = x;
        }
        public static Vector1D operator +(Vector1D a) => a;
        public static Vector1D operator -(Vector1D a) => new Vector1D(-a.X);
        public static Vector1D operator +(Vector1D a, Vector1D b) => new Vector1D(a.X + b.X);
        public static Vector1D operator -(Vector1D a, Vector1D b) => new Vector1D(a.X - b.X);
        public static Vector1D operator *(Vector1D a, Vector1D b) => new Vector1D(a.X * b.X);
        public static Vector1D operator /(Vector1D a, Vector1D b) => new Vector1D(a.X / b.X);
        public Vector1DInt VectorInt => new Vector1DInt((int)X);

        #region Transforms
        public static explicit operator Vector3D(Vector1D b) => new Vector3D(b.X, 0, 0);
        public static explicit operator Vector3DInt(Vector1D b) => new Vector3DInt( (int)b.X, 0, 0);
        public static explicit operator Vector2D(Vector1D b) => new Vector2D(b.X, 0);
        public static explicit operator Vector2DInt(Vector1D b) => new Vector2DInt( (int)b.X, 0);
        public static implicit operator Vector1DInt(Vector1D b) => new Vector1DInt( (int)b.X);
        #endregion
        public override string ToString() => "{" + X + "}";
    }
}
