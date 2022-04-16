using System;

namespace NiTiS.Interaction;

[AttributeUsage(AttributeTargets.Field)]
public class AutomaticFillAttribute : Attribute
{
	public AutomaticFill Type { get; } = AutomaticFill.Ignore;
	public AutomaticFillAttribute(AutomaticFill type)
	{
		Type = type;
	}
}
[Flags]
public enum AutomaticFill : ushort
{
	Ignore = 1,
	ServiceProvider = 2,
}
public static class AutomaticFillExtensions
{
	public static bool IsIgnore(this AutomaticFill filter) => (ushort)filter % 2 != 0;
	public static bool IsValid(this AutomaticFill filter, AutomaticFill required) => filter.HasFlag(required);
}

