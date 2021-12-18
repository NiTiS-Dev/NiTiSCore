namespace NiTiS.Core.Additions
{
    public static class Additions
    {
        public static string TrimWhiteSpaceFromStartAndEnd(this string text)
        {
            while(text[0] == ' ')
            {
                text = text.Substring(1);
            }
            while(text[text.Length - 1] == ' ')
            {
                text = text.TrimEnd(' ');
            }
            return text;
        }
        public static string FormatForValueSet(this string text)
        {
            return text.Replace(":", @"\u003a").Replace("\r", @"\u000d").Replace("\n", @"\u000a");
        }
        public static string FormatFromValueSet(this string text)
        {
            return text.Replace(@"\u003a", ":").Replace(@"\u000d", "\r").Replace(@"\u000a", "\n");
        }
    }
}
