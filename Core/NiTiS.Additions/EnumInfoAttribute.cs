using System;

namespace NiTiS.Additions;

public sealed class EnumInfoAttribute : Attribute
{
	public string Name { get; private set; } = "";
	public string Description { get; private set; } = "";
	public EnumInfoAttribute()
	{

	}
	public EnumInfoAttribute(string name)
	{
		Name = name;
	}
	public EnumInfoAttribute(string name, string description)
	{
		Name = name;
		Description = description;
	}
}