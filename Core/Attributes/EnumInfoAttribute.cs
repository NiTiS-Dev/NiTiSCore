#if NITIS_ENUM_INFO
using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.Core.Attributes
{
    [NiTiSCoreTypeInfo("1.5.0.0", "2.0.0.0")]
    public class EnumInfoAttribute : Attribute
    {
        public string Name { get; private set; } = "";
        public string Description { get; private set; } = "";

        public EnumInfoAttribute()
        {

        }
        public EnumInfoAttribute(string name)
        {
            Name = name;
        }
        public EnumInfoAttribute(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
#endif