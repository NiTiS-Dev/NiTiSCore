// The NiTiS-Dev licenses this file to you under the MIT license.

using System;

namespace NiTiS.Net.Arguments;
public class JustValueArgument : IArgument
{
	public string Name { get; set; }
	public string Spliterator { get; set; }
	public string Value { get; set; }
	public JustValueArgument(string argumentName, string spliterator, string value)
	{
		Name = argumentName;
		Spliterator = spliterator;
		Value = value;
	}
	public static JustValueArgument Of<T>(string name, T item, string spliterator = "=", string? format = null, IFormatProvider? formatProvider = null) where T : IFormattable
	{
		return new(name, spliterator, item.ToString(format, formatProvider));
	}
	/// <inheritdoc/>
	public string Create()
		=> Name + Spliterator + Value;
}
