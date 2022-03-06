using System;
using System.Collections.Generic;

namespace NiTiS.Core.Data
{
    public interface IDataStorage
    {
        public void WriteBool(Boolean value);
        public void WriteByte(Byte value);
        public void WriteByteArray(IEnumerable<byte> value);
        public void WriteInt16(Int16 value);
        public void WriteInt32(Int32 value);
        public void WriteInt64(Int64 value);
        public void WriteSingle(Single value);
        public void WriteDouble(Double value);
        public void WriteString(String value);
        public void WriteChar(Char value);
        public void WriteSByte(SByte value);
        public void WriteUInt16(UInt16 value);
        public void WriteUInt32(UInt32 value);
        public void WriteUInt64(UInt64 value);

        public Boolean ReadBool();
        public Byte ReadByte();
        public IEnumerable<byte> ReadByteArray(int size);
        public Int16 ReadInt16();
        public Int32 ReadInt32();
        public Int64 ReadInt64();
        public Single ReadSingle();
        public Double ReadDouble();
        public String ReadString(int size);
        public Char ReadChar();
        public SByte ReadSByte();
        public UInt16 ReadUInt16();
        public UInt32 ReadUInt32();
        public UInt64 ReadUInt64();
    }
}
