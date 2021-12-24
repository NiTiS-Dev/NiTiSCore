using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Field 
        | AttributeTargets.Property, 
        AllowMultiple = false)]
    public sealed class NiTiSONFieldAttribute : Attribute
    {
        public string Name { get; private set; }
        public NiTiSONFieldAttribute(string name)
        {
            Name = name;
        }
    }
}
