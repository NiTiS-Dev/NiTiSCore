using System;
using System.Reflection;

namespace NiTiS.Core.Reflection;

public class TypeEditor<T>
{
    public Type Type => typeof(T);
    public BindingFlags Flags { get; set; } =
           BindingFlags.Instance |
           BindingFlags.Public |
           BindingFlags.NonPublic |
           BindingFlags.Static;
    public ConstructorInfo? GetFreeConstructor()
    {
        return Type.GetConstructor(Type.EmptyTypes);
    }
    public T? CreateInstanceUseFreeConstructor() => (T)GetFreeConstructor()?.Invoke(null);
}