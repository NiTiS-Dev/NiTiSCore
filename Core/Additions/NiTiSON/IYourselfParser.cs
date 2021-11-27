using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.Core.Additions.NiTiSON
{
    public interface IYourselfParser<ParseType>
    {
        object ParseIn(ParseType o);
        ParseType ParseOut();
    }
}
