using NiTiS.Core.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace NiTiS.Core.Types
{
    [DebuggerDisplay("3DFloat ({X}:{Y}:{Z})")]
    public struct Vector3D : IVector<float>
    {
        public float X;
        public float Y;
        public float Z;
        public float GetValueByDimension(DimensionAxis axis)
        {
            switch (axis)
            {
                    case DimensionAxis.X: return X;
                    case DimensionAxis.Y: return Y;
                    case DimensionAxis.Z: return Z;
                default: return 0;
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
        #region Static Fields
        public static Vector3D Foward => new Vector3D(1, 0, 0);
        public static Vector3D Backwards => new Vector3D(-1, 0, 0);
        public static Vector3D Right => new Vector3D(0, 0, 1);
        public static Vector3D Left => new Vector3D(0, 0, -1);
        public static Vector3D Up => new Vector3D(0, 1, 0);
        public static Vector3D Down => new Vector3D(0, -1, 0);
        #endregion
        public override string ToString() => "{" + X + ":" + Y + ":" + Z + "}";
        public double LengthSquared => X * X + Y * Y + Z * Z;
        public double Length => System.Math.Sqrt(LengthSquared);
        public void Normalize()
        {
            X = (float)(X / Length);
            Y = (float)(Y / Length);
            Z = (float)(Z / Length);
        }
    }
}
