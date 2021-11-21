using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiTiS.Core.Types
{
    public static class GofsFormater
    {
        public static string FormatString(string text, string key)
        {
            return $"<{key.Replace(':','-')}:{text}>";
        }
    }
}
