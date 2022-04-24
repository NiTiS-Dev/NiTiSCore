using NiTiS.Additions;
using NiTiS.Reflection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiTiS.IO.Format.TABS;

public static class TABSSerializer
{
	[Obsolete]
	public static TABSElement ParseObject(string tabs)
	{
		string[] lines = tabs.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

		List<TABSLine> tabLines = new();

		foreach (string line in lines)
		{
			tabLines.Add(ParseLine(line));
		}

		return new TABSJustValue();
	}
	internal static TABSLine ParseLine(string line)
	{
		line = line.TrimEnd(' ');
		if (line.Length == 0)
		{
			return new TABSLine(TABSLineType.None);
		}
		int whiteSpaceCount = 0;
		while(line.StartsWith(" "))
		{
			line = line.Substring(0, 1);
			whiteSpaceCount++;
		}
		if (line.StartsWith("#"))
		{
			return new TABSLine(TABSLineType.Comment);
		}
		int indexOfSpliterator = line.IndexOf(':');
		int indexOfDictSpliterator = line.IndexOf('=');
		if (indexOfDictSpliterator == -1)
		{
			if (indexOfSpliterator == -1)
			{
				return new TABSLine(TABSLineType.JV, whiteSpaceCount, new TABSJustValue(null, line));
			}
			else
			{

			}
		} 
		else
		{
			// return new TABSLine(TABSLineType.DictonaryField, whiteSpaceCount, new )
		}
		return default;
	}
	[Obsolete]
	public static T? DeserializeAnonymousType<T>(string tabs, T definition)
	{
		return Deserialize<T>(tabs);
	}
	public static T? Deserialize<T>(string tabs)
	{
		Class @class = Class.Of<T>();



		return default;
	}
	public static string Serialize(object item)
	{
		return GetElementViaObject(item).ToString(0);
	}
	private static TABSElement GetElementViaObject(object obj)
	{
		if (obj is Delegate @delegate)
		{
			throw new Exception("Delegates are not supported in TABS 1.0");
		}
		if (obj is null) return new TABSJustValue();
		if (obj is ITABSSerializable ser)
		{
			return ser.Serialize();
		}
		TABSJustValue? basicValue = GetBasicElementViaObject(obj);
		if (basicValue is not null)
		{
			return basicValue;
		}
		if (obj is Array arr)
		{
			TABSList tabs = new();
			foreach(object i in arr)
			{
				tabs.Add(GetElementViaObject(i));
			}
			return tabs;
		}
		if (obj is IList list)
		{
			TABSList tabs = new();
			IEnumerator enumerator = list.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object item = enumerator.Current;
				tabs.Add(GetElementViaObject(item)); 
			}
			return tabs;
		}
		if (obj is IDictionary dict)
		{
			TABSDictonary tabs = new();
			foreach(DictionaryEntry o in dict)
			{
				TABSJustValue key = GetBasicElementViaObject(o.Key);
				TABSElement value = GetElementViaObject(o.Value);
				tabs.Add(key, value);
			}
			return tabs;
		}
		TABSObject element = new();
		Class.Of(obj).Fields.Iterate( (tzis) =>
		{
			element.AddField(tzis.Name, GetElementViaObject(tzis.GetValue(obj)));
		});
		return element;
	}
	[DebuggerStepThrough]
	private static TABSJustValue? GetBasicElementViaObject(object obj)
	{
		if (obj is Byte i)
		{
			return new TABSJustValue(i);
		}
		if (obj is Int16 i16)
		{
			return new TABSJustValue(i16);
		}
		if (obj is Int32 i32)
		{
			return new TABSJustValue(i32);
		}
		if (obj is Int64 i64)
		{
			return new TABSJustValue(i64);
		}
		if (obj is SByte ui)
		{
			return new TABSJustValue(ui);
		}
		if (obj is UInt16 ui16)
		{
			return new TABSJustValue(ui16);
		}
		if (obj is UInt32 ui32)
		{
			return new TABSJustValue(ui32);
		}
		if (obj is UInt64 ui64)
		{
			return new TABSJustValue(ui64);
		}
		if (obj is Char character)
		{
			return new TABSJustValue(character);
		}
		if (obj is Boolean boolka)
		{
			return new TABSJustValue(boolka);
		}
		if (obj is String str)
		{
			return new TABSJustValue(str);
		}
		if (obj is DateTime dateTime)
		{
			return new TABSJustValue(dateTime);
		}
		if (obj is Single single)
		{
			return new TABSJustValue(single);
		}
		if (obj is Double dobl)
		{
			return new TABSJustValue(dobl);
		}
		return null;
	}
}
