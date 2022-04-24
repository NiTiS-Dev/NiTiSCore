namespace NiTiS.IO.Format.TABS;

internal class TABSLine
{
	public TABSElement Value { get; }
	public TABSLineType LineType { get; }
	public int WhiteSpaceCount { get; }
	public TABSLine(TABSLineType type, int whitespaceCount = 0, TABSElement value = default)
	{
		LineType = type;
		WhiteSpaceCount = whitespaceCount;
		Value = value;
	}
}
internal enum TABSLineType : byte
{
	//Whitespace
	None = 0,
	// [
	NamelessArrayStart = 1,
	// ]
	NamelessArrayEnd = 2,
	// field: ___
	JVField = 3,
	// field: 
	ObjectStart = 4,
	// #
	Comment = 5,
	// "ads" or 123 or (2022, 12, 32 | 0:0:0:0)
	JV = 6
}
