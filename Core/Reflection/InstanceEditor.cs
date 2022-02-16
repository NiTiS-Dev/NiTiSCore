#if NITIS_REFLECTION
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace NiTiS.Core.Reflection;

public sealed class InstanceEditor<EDIT>
{
    private readonly Type editType;
    public EDIT Instance { get; set; }
    public InstanceEditor(EDIT instance = default)
    {
        this.Instance = instance;
        editType = typeof(EDIT);
    }
    public IEnumerable<object> GetVariableValueEnumerator()
    {
        return editType.GetFields(
            BindingFlags.Instance |
            BindingFlags.Public |
            BindingFlags.NonPublic |
            BindingFlags.Static
            ).Select(s => s.GetValue(Instance));
    }
    public IEnumerable<object> GetVariableEnumerator()
    {
        return editType.GetFields(
            BindingFlags.Instance |
            BindingFlags.Public |
            BindingFlags.NonPublic |
            BindingFlags.Static
            );
    }
    public bool IsEnum => editType.IsEnum;
}
#endif