using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NiTiS.Core.Enums;

namespace NiTiS.Core.Collections
{
    public class EnumCollection<Enu> : IEnumerable where Enu : struct, Enum
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
        protected List<Enu> list = new List<Enu>();
        public static EnumCollection<Enu> Of<Enu>(params Enu[] enums) where Enu : struct, Enum
        {
            var n = new EnumCollection<Enu>();
            n.list.AddRange(enums);
            return n;
        }
        public static EnumCollection<Enu> Of<Enu>() where Enu : struct, Enum
        {
            var values = Enum.GetValues(typeof(Enu));
            return new EnumCollection<Enu>(values);
        }
        private EnumCollection() { }
        private EnumCollection(System.Array aray)
        {
            foreach(Enu enu in aray)
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
