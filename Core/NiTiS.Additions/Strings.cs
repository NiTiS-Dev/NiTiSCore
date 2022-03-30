using System;
using System.Collections;
using System.Linq;

namespace NiTiS.Additions;

/// <summary>
/// Provides some strings functions
/// </summary>
public static class Strings
{
	/// <summary>
	/// Repeat string X times
	/// </summary>
	/// <param name="value">String to repeat</param>
	/// <param name="repeat">Amount to repeat</param>
	/// <returns></returns>
	public static string Multiply(this string value, int repeat)
	{
		return String.Concat(Enumerable.Repeat(value, repeat));
	}
	/// <summary>
	/// Creates string using some array
	/// </summary>
	/// <returns>For array {0, 1, 2 ,3} returns "[0, 1, 2, 3]"</returns>
	public static string FromArray(IEnumerable enumarable, string start = "[", string end = "]", string seperator = ", ", string nullName = "null")
	{
		string text = start;
		System.Collections.Generic.List<string> list = new();
		foreach (object? item in enumarable)
		{
			list.Add(item?.ToString() ?? nullName);
		}
		int max = list.Count;
		for (int i = 0; i < max; i++)
		{
			text += list[i] + ((max - 1 == i) ? String.Empty : seperator);
		}
		return text + end;
	}
	public static string ReplaceSelf(this string self, string from, string to)
	{
		if (from is null) throw new ArgumentNullException(nameof(from));
		if (to is null) throw new ArgumentNullException(nameof(to));
		return self.Replace(from, to);
	}
	public static string ReplaceSelf(this string self, char from, char to) => self.Replace(from, to);
}