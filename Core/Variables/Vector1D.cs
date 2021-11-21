using System.Diagnostics;

namespace NiTiS.Core.Variables
{
    [DebuggerDisplay("1DFloat ({X})")]
    public struct Vector1D : IVector<float>, INiTiSType
    {
        private static NiVersion version = new NiVersion(1,"1.0");
        public NiVersion Version => version;

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
        public static readonly Vector1D left = new Vector1D(-1f);
        public static readonly Vector1D right = new Vector1D(-1f);
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

        public override string ToString() => "{" + X + "}";
    }
}
