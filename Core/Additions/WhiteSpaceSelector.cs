using System;

namespace NiTiS.Core.Additions
{
    public sealed class WhiteSpaceSelector : ISelector
    {
        private int matchs = 0;
        public int Matchs => matchs;

        public string Convert(string value, bool invert = false)
        {
            string newValue = "";
#if NITIS_EXTENSIONS
            Additions.ForEachElements<char>(value, (e) =>
            {
                if (Char.IsWhiteSpace(e))
                {
                    matchs++;
                    if (invert)
                    {
                        newValue += e;
                    }
                }
                else
                {
                    if (!invert)
                    {
                        newValue += e;
                    }
                }
            });
#else
            foreach(char c in value) {
                if (Char.IsWhiteSpace(c))
                {
                    matchs++;
                    if (invert)
                    {
                        newValue += c;
                    }
                }
                else
                {
                    if (!invert)
                    {
                        newValue += c;
                    }
                }
            }
#endif
            return newValue;
        }
    }
}
