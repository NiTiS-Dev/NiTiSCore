namespace NiTiS.IO.Format.TABS;

public class TABSJustValue : TABSElement
{
	private string text;
	public TABSJustValue(int item)
	{
		this.text = item.ToString();
	}
	public int AsInt32() => Int32.Parse(this.text);
	public TABSJustValue(uint item)
	{
		this.text = item.ToString();
	}
	public uint AsUInt32() => UInt32.Parse(this.text);
	public TABSJustValue(byte item)
	{
		this.text = item.ToString();
	}
	public byte AsByte() => Byte.Parse(this.text);
	public TABSJustValue(sbyte item)
	{
		this.text = item.ToString();
	}
	public sbyte AsSByte() => SByte.Parse(this.text);
	public TABSJustValue(short item)
	{
		this.text = item.ToString();
	}
	public short AsInt16() => Int16.Parse(this.text); 
	public TABSJustValue(ushort item)
	{
		this.text = item.ToString();
	}
	public ushort AsUInt16() => UInt16.Parse(this.text);
	public TABSJustValue(long item)
	{
		this.text = item.ToString();
	}
	public long AsInt64() => Int64.Parse(this.text);
	public TABSJustValue(ulong item)
	{
		this.text = item.ToString();
	}
	public ulong AsUInt64() => UInt64.Parse(this.text);
	public TABSJustValue(float item)
	{
		this.text = item.ToString();
	}
	public float AsSingle() => Single.Parse(this.text);
	public TABSJustValue(double item)
	{
		this.text = item.ToString();
	}
	public double AsDouble() => Double.Parse(this.text);
	public TABSJustValue(bool item)
	{
		this.text = item ? "true" : "false";
	}
	public TABSJustValue() => this.text = "null";
	public bool AsBoolean() => 
		  this.text == "true" ? true 
		: this.text == "false" ? false 
		: throw new FormatException();
	public TABSJustValue(char item)
	{
		this.text = $"'{item}'";
	}
	public char AsChar() => Char.Parse(this.text.TrimEnd('\'').TrimStart('\''));
	public TABSJustValue(DateTime item)
	{
		this.text = $"({item.Year}, {item.Month}, {item.Day} | {item.Hour}:{item.Minute}:{item.Second}:{item.Millisecond})";
	}
	public DateTime AsDateTime()
	{
		string clearText = this.text.TrimEnd(')').TrimStart('(');
		string[] dateTime = clearText.Split('|');
		string[] date = dateTime[0].Split(',');
		string[] time = dateTime[1].Split(':');
		return new DateTime(
			Int32.Parse(date[0]),
			Int32.Parse(date[1]),
			Int32.Parse(date[2]),
			Int32.Parse(time[0]),
			Int32.Parse(time[1]),
			Int32.Parse(time[2]),
			Int32.Parse(time[3])
			);
	}
	public TABSJustValue(string text)
	{
		this.text = $"\"{ToTabsString(text)}\"";
	}
	public string AsText() => FromTabsString(this.text.TrimEnd('"').TrimStart('"'));
	internal TABSJustValue(object? _, string value)
	{
		this.text = value;
	}
	public static string ToTabsString(string text) => text.Replace("\"", "\\\"").Replace("\n", "\\n").Replace("\r", "\\r");
	public static string FromTabsString(string text) => text.Replace("\\\"", "\"").Replace("\\n", "\n").Replace("\\r", "\r");

	public override string ToString() => ToString(0);
	public string ToString(int depth)
	{
		return this.text;
	}
}
