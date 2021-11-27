using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace NiTiS.Core.Variables
{
    [DebuggerDisplay("3DFloat ({X}:{Y}:{Z})")]
    public struct Vector3D : IVector<float>
    {
        public float X;
        public float Y;
        public float Z;
        public const int dimensionCount = 3;
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
            else if (dimension == 'z' || dimension == 'Y')
            {
                return Z;
            }
            else
            {
                return 0;
            }
        }

        public Vector3D(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public static Vector3D operator +(Vector3D a) => a;
        public static Vector3D operator -(Vector3D a) => new Vector3D(-a.X, -a.Y, -a.Z);
        public static Vector3D operator +(Vector3D a, Vector3D b) => new Vector3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        public static Vector3D operator -(Vector3D a, Vector3D b) => new Vector3D(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        public static Vector3D operator *(Vector3D a, Vector3D b) => new Vector3D(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
        public static Vector3D operator /(Vector3D a, Vector3D b) => new Vector3D(a.X / b.X, a.Y / b.Y, a.Z / b.Z);

        #region Transforms
        public static implicit operator Vector3DInt(Vector3D b) => new Vector3DInt((int)b.X, (int)b.Y, (int)b.Z);
        public static implicit operator Vector2D(Vector3D b) => new Vector2D(b.X,b.Y);
        public static implicit operator Vector2DInt(Vector3D b) => new Vector2DInt( (int)b.X, (int)b.Y);
        public static implicit operator Vector1D(Vector3D b) => new Vector1D(b.X);
        public static implicit operator Vector1DInt(Vector3D b) => new Vector1DInt( (int)b.X);
        #endregion

        public override string ToString() => "{" + X + ":" + Y + ":" + Z + "}";
    }
}
