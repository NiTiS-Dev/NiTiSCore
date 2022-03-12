using System.Linq;

namespace NiTiS.Additions;

public static class Strings
{
    public static string Multiply(this string value, int repeat)
    {
        return string.Concat(Enumerable.Repeat(value, repeat));
    }
}