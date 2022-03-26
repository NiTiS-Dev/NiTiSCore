using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NiTiS.Reflection;

public sealed class InstanceEditor
{
    private readonly Type editType;
    public object Instance { get; set; }
    public BindingFlags Flags { get; set; } =
            BindingFlags.Instance |
            BindingFlags.Public |
            BindingFlags.NonPublic |
            BindingFlags.Static;
    public InstanceEditor(object? instance = default)
    {
        this.Instance = instance!;
        editType = instance!.GetType();
    }
    public IEnumerable<object?> GetVariableValueEnumerable()
    {
        return editType.GetFields(Flags).Select(s => s.GetValue(Instance));
    }
    public IEnumerable<FieldInfo> GetVariableEnumerable()
    {
        return editType.GetFields(Flags);
    }
    public IEnumerable<PropertyInfo> GetProperityEnumerable()
    {
        return editType.GetProperties(Flags);
    }
    public IEnumerable<object?> GetProperityValueEnumerable()
    {
        return editType.GetProperties(Flags).Where(s => s.CanRead).Select(s => s.GetValue(Instance));
    }
    public bool IsEnum => editType.IsEnum;
    public Array EnumValues => editType.GetEnumValues();
}