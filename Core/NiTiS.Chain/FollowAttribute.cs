using System;

namespace NiTiS.Chain;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class FollowAttribute : Attribute
{
    public Type Type { get; private set; }
    public string MethodName { get; private set; }
    public FollowAttribute(Type type, string name)
    {
        this.Type = type;
        this.MethodName = name;
    }
}
public sealed class FollowAttribute<T> : FollowAttribute
{
    public FollowAttribute(string name) : base(typeof(T), name)
    {

    }
}