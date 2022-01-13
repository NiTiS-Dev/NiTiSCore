using System;
using System.Collections;
using System.Collections.Generic;
using NiTiS.Core.Enums;
using NiTiS.Core.Attributes;

namespace NiTiS.Core.Collections
{
    [NiTiSCoreTypeInfo("1.3.0.0", "2.0.0.0")]
    public class EnumCollection<ET> : IEnumerable where ET : struct, Enum
    {
        public static EnumCollection<DimensionAxis> Axis3D
        {
            get
            {
                return EnumCollection<DimensionAxis>.Of<DimensionAxis>(DimensionAxis.X, DimensionAxis.Y, DimensionAxis.Z);
            }
        }
        public static EnumCollection<DimensionAxis> Axis2D
        {
            get
            {
                return EnumCollection<DimensionAxis>.Of<DimensionAxis>(DimensionAxis.X, DimensionAxis.Y);
            }
        }
        public static EnumCollection<DimensionAxis> Axis1D
        {
            get
            {
                return EnumCollection<DimensionAxis>.Of<DimensionAxis>(DimensionAxis.X);
            }
        }
        protected List<ET> list = new List<ET>();
        public static EnumCollection<Enu> Of<Enu>(params Enu[] enums) where Enu : struct, Enum
        {
            var enumCollection = new EnumCollection<Enu>();
            enumCollection.list.AddRange(enums);
            return enumCollection;
        }
        public static EnumCollection<Enu> Of<Enu>() where Enu : struct, Enum
        {
            var values = Enum.GetValues(typeof(Enu));
            return new EnumCollection<Enu>(values);
        }
        private EnumCollection() { }
        private EnumCollection(Array array)
        {
            if (array is null) return;
            foreach(ET enu in array)
            {
                list.Add(enu);
            }
        }
        public IEnumerator GetEnumerator()
        {
            return list.GetEnumerator();
        }
    }
}
