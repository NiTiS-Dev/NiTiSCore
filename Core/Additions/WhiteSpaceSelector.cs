using NiTiS.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.Core.Additions
{
    [NiTiSCoreTypeInfo("2.0.0.0", "2.0.0.0")]
    public sealed class WhiteSpaceSelector : ISelector
    {
        private int matchs = 0;
        public int Matchs => matchs;

        public string Convert(string value, bool invert = false)
        {
            string newValue = "";
            value.ForEachElements(e =>
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
            return newValue;
        }
    }
}
