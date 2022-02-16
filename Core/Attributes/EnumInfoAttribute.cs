#if NITIS_ENUM_INFO
using System;

namespace NiTiS.Core.Attributes
{
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