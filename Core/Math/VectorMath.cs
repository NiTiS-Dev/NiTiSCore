using NiTiS.Core.Attributes;
using NiTiS.Core.Collections;
using NiTiS.Core.Enums;
using NiTiS.Core.Types;

namespace NiTiS.Core.Math
{
    [NiTiSCoreTypeInfo("1.3.0.0", "2.0.0.0")]
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
        public static bool CompareVectors<T>(IVector<T> left, IVector<T> right, EnumCollection<DimensionAxis> axis)
        {
            foreach(DimensionAxis i in axis)
            {
                if(!left.GetValueByDimension(i).Equals(right.GetValueByDimension(i)))
                    return false;
            }
            return true;
        }
        public static bool CompareVectors<T>(IVector<T> left, IVector<T> right, params DimensionAxis[] axis)
        {
            foreach (DimensionAxis i in axis)
            {
                if (!left.GetValueByDimension(i).Equals(right.GetValueByDimension(i)))
                    return false;
            }
            return true;
        }
    }
}
