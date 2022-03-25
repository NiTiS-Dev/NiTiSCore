using System;
using System.Reflection;

namespace NiTiS.Chain;

public static class Chains
{
    public static void Initialize()
    {
        foreach(Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            Initialize(assembly);
        }
    }
    public static void Initialize(Assembly asm)
    {
        foreach(Type type in asm.GetTypes())
        {
            Initialize(type);
        }
    }
    public static void Initialize<T>() => Initialize(typeof(T));
    public static void Initialize(Type type)
    {

    }
}
