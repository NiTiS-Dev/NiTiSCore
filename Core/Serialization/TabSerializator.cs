#if NITIS_REFLECTION
using NiTiS.Core.Reflection;
using System;
using System.Linq;

namespace NiTiS.Core.Serialization;

public class TabSerializator : INiTiSSerializator<string>
{
    public bool Align { get; private set; }
    public string NewLine => Align ? Environment.NewLine : String.Empty;
    public string Arrow => Align ? " -> " : "->";
    public TabSerializator(bool align = true)
    {
        Align = align;
    }
    public string Serialize<T>(T item)
    {
        string text = "<TAB:00:~>" + NewLine;
        InstanceEditor editor = new(item);
        foreach (var v in editor.GetVariableEnumerable())
        {
            TabValueAttribute atr = (TabValueAttribute)v.GetCustomAttributes(typeof(TabValueAttribute), true).FirstOrDefault();
            text += Parse(atr is null ? v.Name : atr.ID, v.GetValue(item)) + ";" + NewLine;
        }
        return text;
    }
    public T Deserialize<T>(string tabs, T item = default)
    {

        return item;
    }
    private string Parse(string name, object item)
    {
        if (item is null) return name + Arrow + "null";
        if (item is string str)
        {
            return name + Arrow + str.Replace("\\", @"\\").Replace("\"", "\\\"");
        }
        if (item is char c)
        {
            return name + Arrow + c;
        }
        if (item is Array array)
        {
            string text = "[" + NewLine;
            foreach (var element in array)
            {

            }
            return name + Arrow + text + "]";
        }
        return name + Arrow + "_";
    }
}
#endif