using NiTiS.Core.Attributes;
using NiTiS.Core.Types;
using System;
using NiTiS.Core.Enums;
using NiTiS.Core.Collections;

namespace NiTiS.Core.Math
{
    public static class VectorMath
    {
        public static Vector4D Vector4DOf(float size)
        {
            return new Vector4D(size, size, size, size);
        }
        public static Vector3D Vector3DOf(float size)
        {
            return new Vector3D(size, size, size);
        }
        public static Vector2D Vector2DOf(float size)
        {
            return new Vector2D(size, size);
        }
        public static Vector1D Vector1DOf(float size)
        {
            return new Vector1D(size);
        }
        public static bool CompareVectors(IVector<float> left, IVector<float> right, EnumCollection<DimensionAxis> axis)
        {
            return CompareVectors<float>(left, right, axis);
        }
        public static bool CompareVectors<T>(IVector<T> left, IVector<T> right, EnumCollection<DimensionAxis> axis)
        {
            foreach(DimensionAxis i in axis)
            {
                if(!left.GetValueByDimension(i).Equals(right.GetValueByDimension(i)))
                    return false;
            }
            return true;
        }
    }
}
