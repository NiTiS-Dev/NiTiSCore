using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.Core.Attributes
{
    [NiTiSCoreTypeInfo("2.0.0.0","2.0.0.0")]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface | AttributeTargets.Delegate | AttributeTargets.Enum, AllowMultiple = false, Inherited = false)]
    public sealed class NiTiSCoreTypeInfoAttribute : Attribute
    {
        public Version CreateVersion { get; private set; }
        public Version LastUpdateVersion { get; private set; }
        public NiTiSCoreTypeInfoAttribute(string createVersion, string lastUpdateVersion)
        {
            CreateVersion = Version.Parse(createVersion);
            LastUpdateVersion = Version.Parse(lastUpdateVersion);
        }
    }
}
