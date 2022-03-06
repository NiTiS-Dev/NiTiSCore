using System;

namespace NiTiS.Core.Serialization;
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public sealed class TabValueAttribute : Attribute
{
    public string ID { get; private set; }
    public TabValueAttribute(string id)
    {
        this.ID = id;
    }
}