using System;
using System.Diagnostics;

namespace NiTiS.Core.Variables
{
    [DebuggerDisplay("1DInt ({X})")]
    public struct Vector1DInt : IVector<int>
    {

        public int X;
        public const int dimensionCount = 1;
        public int GetDimensionCount()
        {
            return dimensionCount;
        }

        public int GetValueByDimension(char dimension)
        {
            if (dimension == 'x' || dimension == 'X')
            {
                return X;
            }
            else
            {
                return 0;
            }
        }

        public Vector1DInt(int x = 0)
        {
            X = x;
        }
        public static Vector1DInt operator +(Vector1DInt a) => a;
        public static Vector1DInt operator -(Vector1DInt a) => new Vector1DInt(-a.X);
        public static Vector1DInt operator +(Vector1DInt a, Vector1DInt b) => new Vector1DInt(a.X + b.X);
        public static Vector1DInt operator -(Vector1DInt a, Vector1DInt b) => new Vector1DInt(a.X - b.X);
        public static Vector1DInt operator *(Vector1DInt a, Vector1DInt b) => new Vector1DInt(a.X * b.X);
        public static Vector1DInt operator /(Vector1DInt a, Vector1DInt b) => new Vector1DInt(a.X / b.X);
        
        #region Transforms
        public static explicit operator Vector3D(Vector1DInt b) => new Vector3D(b.X, 0, 0);
        public static explicit operator Vector3DInt(Vector1DInt b) => new Vector3DInt(b.X, 0, 0);
        public static explicit operator Vector2D(Vector1DInt b) => new Vector2D(b.X, 0);
        public static explicit operator Vector2DInt(Vector1DInt b) => new Vector2DInt(b.X, 0);
        public static implicit operator Vector1D(Vector1DInt b) => new Vector1D(b.X);
        #endregion

        public override string ToString() => "{" + X + "}";
    }
}
