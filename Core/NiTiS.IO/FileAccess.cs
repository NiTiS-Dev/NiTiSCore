namespace NiTiS.IO;

[Flags]
public enum FileAccess : byte
{
    Read = 1,
    Write = 2,


    Full = Read | Write
}