using System;

namespace NiTiS.Core.Serialization;

public struct NiTiSHeader
{
    private readonly string header;
    private readonly byte version;
    private readonly string argument;
    /// <param name="header"> TAB:00:~ </param>
    public NiTiSHeader(string header)
    {
        string[] args = header.TrimEnd('>').TrimStart('<').Split(':');
        this.header = args[0];
        this.version = Byte.Parse(args[1], System.Globalization.NumberStyles.HexNumber);
        this.argument = args[2];
    }
    public string Header => this.header;
    public byte Version => this.version;
    public string Argument => this.argument;
}