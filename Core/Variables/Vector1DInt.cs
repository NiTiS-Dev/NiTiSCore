using System;
using System.Diagnostics;

namespace NiTiS.Core.Variables
{
    [DebuggerDisplay("1DInt ({X})")]
    public struct Vector1DInt : IVector<int>, INiTiSType
    {
        private static NiVersion version = new NiVersion(1, "1.0");
        public NiVersion Version => version;

        public int X;
        public const int dimensionCount = 1;
        public int GetDimensionCount()
        {
            return dimensionCount;
        }

        public int GetValueByDimension(char dimension)
        {
            throw new NotImplementedException();
        }
        public static readonly Vector1DInt left = new Vector1DInt(-1);
        public static readonly Vector1D right = new Vector1D(-1);

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
        public Vector1D Vector => new Vector1D(X);

        public override string ToString() => "{" + X + "}";
    }
}
