using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.Core.Data
{
    public class BinaryDataStorage : IDataStorage
    {
        private Queue<byte> bytes = new Queue<byte>();
        private BinaryDataStorage() { }
        public static BinaryDataStorage CreateForRead(byte[] bytes)
        {
            BinaryDataStorage storage = new BinaryDataStorage();
            foreach(byte b in bytes)
            {
                storage.bytes.Enqueue(b);
            }
            return storage;
        }
        public static BinaryDataStorage CreateForWrite() => new BinaryDataStorage();

        public bool ReadBool()
        {
            byte bt = bytes.Dequeue();
            return bt == 1;
        }

        public byte ReadByte()
        {
            return bytes.Dequeue();
        }

        public char ReadChar()
        {
            return Convert.ToChar(bytes.Dequeue());
        }

        public double ReadDouble()
        {
            byte[] bt = new byte[8];
            bt[0] = bytes.Dequeue();
            bt[1] = bytes.Dequeue();
            bt[2] = bytes.Dequeue();
            bt[3] = bytes.Dequeue();
            bt[4] = bytes.Dequeue();
            bt[5] = bytes.Dequeue();
            bt[6] = bytes.Dequeue();
            bt[7] = bytes.Dequeue();
            return BitConverter.ToDouble(bt, 0);
        }

        public short ReadInt16()
        {
            byte[] bt = new byte[2];
            bt[0] = bytes.Dequeue();
            bt[1] = bytes.Dequeue();
            return BitConverter.ToInt16(bt, 0);
        }

        public int ReadInt32()
        {
            byte[] bt = new byte[4];
            bt[0] = bytes.Dequeue();
            bt[1] = bytes.Dequeue();
            bt[2] = bytes.Dequeue();
            bt[3] = bytes.Dequeue();
            return BitConverter.ToInt32(bt, 0);
        }

        public long ReadInt64()
        {
            byte[] bt = new byte[8];
            bt[0] = bytes.Dequeue();
            bt[1] = bytes.Dequeue();
            bt[2] = bytes.Dequeue();
            bt[3] = bytes.Dequeue();
            bt[4] = bytes.Dequeue();
            bt[5] = bytes.Dequeue();
            bt[6] = bytes.Dequeue();
            bt[7] = bytes.Dequeue();
            return BitConverter.ToInt32(bt, 0);
        }

        public sbyte ReadSByte()
        {
            return Convert.ToSByte(bytes.Dequeue());
        }

        public float ReadSingle()
        {
            byte[] bt = new byte[4];
            bt[0] = bytes.Dequeue();
            bt[1] = bytes.Dequeue();
            bt[2] = bytes.Dequeue();
            bt[3] = bytes.Dequeue();
            return BitConverter.ToSingle(bt, 0);
        }

        public string ReadString(int size)
        {
            string text = "";
            for(int i = 0; i < size; i++)
            {
                text += Convert.ToChar(bytes.Dequeue());
            }
            return text;
        }

        public ushort ReadUInt16()
        {
            byte[] bt = new byte[2];
            bt[0] = bytes.Dequeue();
            bt[1] = bytes.Dequeue();
            return BitConverter.ToUInt16(bt, 0);
        }

        public uint ReadUInt32()
        {
            byte[] bt = new byte[4];
            bt[0] = bytes.Dequeue();
            bt[1] = bytes.Dequeue();
            bt[2] = bytes.Dequeue();
            bt[3] = bytes.Dequeue();
            return BitConverter.ToUInt32(bt, 0);
        }

        public ulong ReadUInt64()
        {
            byte[] bt = new byte[8];
            bt[0] = bytes.Dequeue();
            bt[1] = bytes.Dequeue();
            bt[2] = bytes.Dequeue();
            bt[3] = bytes.Dequeue();
            bt[4] = bytes.Dequeue();
            bt[5] = bytes.Dequeue();
            bt[6] = bytes.Dequeue();
            bt[7] = bytes.Dequeue();
            return BitConverter.ToUInt64(bt, 0);
        }

        public void WriteBool(bool value)
        {
            bytes.Enqueue( Convert.ToByte(value) );
        }

        public void WriteByte(byte value)
        {
            bytes.Enqueue(value);
        }

        public void WriteChar(char value)
        {
            bytes.Enqueue( Convert.ToByte(value) );
        }

        public void WriteDouble(double value)
        {
            foreach(byte bt in BitConverter.GetBytes(value))
            {
                bytes.Enqueue( bt );
            }
        }

        public void WriteInt16(short value)
        {
            foreach (byte bt in BitConverter.GetBytes(value))
            {
                bytes.Enqueue(bt);
            }
        }

        public void WriteInt32(int value)
        {
            foreach (byte bt in BitConverter.GetBytes(value))
            {
                bytes.Enqueue(bt);
            }
        }

        public void WriteInt64(long value)
        {
            foreach (byte bt in BitConverter.GetBytes(value))
            {
                bytes.Enqueue(bt);
            }
        }

        public void WriteSByte(sbyte value)
        {
            bytes.Enqueue(Convert.ToByte(value));
        }

        public void WriteSingle(float value)
        {
            foreach (byte bt in BitConverter.GetBytes(value))
            {
                bytes.Enqueue(bt);
            }
        }

        public void WriteString(string value)
        {
            foreach(char c in value)
            {
                bytes.Enqueue(Convert.ToByte(c));
            }
        }

        public void WriteUInt16(ushort value)
        {
            foreach (byte bt in BitConverter.GetBytes(value))
            {
                bytes.Enqueue(bt);
            }
        }

        public void WriteUInt32(uint value)
        {
            foreach (byte bt in BitConverter.GetBytes(value))
            {
                bytes.Enqueue(bt);
            }
        }

        public void WriteUInt64(ulong value)
        {
            foreach (byte bt in BitConverter.GetBytes(value))
            {
                bytes.Enqueue(bt);
            }
        }
        public byte[] FinishRead()
        {
            return bytes.ToArray();
        }

        public void WriteByteArray(IEnumerable<byte> value)
        {
            foreach (byte bt in value)
            {
                bytes.Enqueue(bt);
            }
        }

        public IEnumerable<byte> ReadByteArray(int size)
        {
            for (int i = 0; i < size; i++)
            {
                yield return bytes.Dequeue();
            }
        }
    }
}
