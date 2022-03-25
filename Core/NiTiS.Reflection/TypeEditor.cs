using System;
using System.Reflection;
using SType = System.Type;

namespace NiTiS.Reflection;

public class TypeEditor
{
    public SType Type { get; private set; }
    public TypeEditor(SType type)
    {
        this.Type = type;
    }
    public BindingFlags Flags { get; set; } =
           BindingFlags.Instance |
           BindingFlags.Public |
           BindingFlags.NonPublic |
           BindingFlags.Static;
    public ConstructorInfo? GetFreeConstructor()
    {
        return Type.GetConstructor(SType.EmptyTypes);
    }
    public object CreateInstanceThrowFreeConstructor() => GetFreeConstructor()?.Invoke(null);
    public CAST CreateInstanceThrowFreeConstructor<CAST>() => (CAST)GetFreeConstructor()?.Invoke(null);
    public MethodInfo? GetMethod(string name) => Type.GetMethod(name, Flags);
    public MethodInfo[] GetMethods() => Type.GetMethods(Flags);
}