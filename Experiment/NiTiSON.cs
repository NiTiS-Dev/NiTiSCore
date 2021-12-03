using System;
using System.Text;
using NiTiS.Core.Additions;
using NiTiS.Core.Types;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace NiTiS.Experiment
{
	public static class Program
	{
		public static void Main()
		{
			try
			{


				var nts = new NTSON();
				nts.Place("gay", 45000);
				nts.Place("gogol", 4099);
				nts.Place("kirusha", 201);

				File.WriteAllBytes("/sdcard/.code/DSharp/raw.nitison", nts.Bytes);
				byte[] btsRead = File.ReadAllBytes("/sdcard/.code/DSharp/raw.nitison");
				string str = "";
				string name = "";
				byte[] obj = new byte[0];
				byte objIndex = 0;
				int read = -1;
				bool readName = false;
				bool readSize = false;
				Dictionary<string, byte[]> dict = new Dictionary<string, byte[]>();
				for (int index = 0; index < btsRead.Length; index++)
				{
					byte bt = btsRead[index];
					//Console.WriteLine(bt);
					if (index <= 9)
					{
						if (index < 9)
						{
							str += (char)bt;
						}
						if (index == 9 && str != "_nitison_")
						{
							throw new Exception("Invalid File format");
						}
						else
						{
							readSize = true;
						}
					}
					else
					{
						Console.WriteLine(objIndex + ">" + index + "Y" + bt);
						if (readSize)
						{
							read = bt;
							readSize = false;
							readName = !readName;
							Console.WriteLine($"ReadSize: {bt}; ReadName: {readName}");
						}
						else if (read > 0)
						{
							if (readName)
							{
								name += (char)bt;
							}
							else
							{
								if (objIndex == 0)
								{
									obj = new byte[read];
								}
								obj[objIndex] = bt;
								objIndex++;
							}
							read--;
							if (read <= 0)
							{
								if (index + 1 == btsRead.Length)
								{

								}
								else
								{
									readSize = true;
								}
								if (readName)
								{
									str += name + ":";
									name = "";
								}
								else
								{
									dict.Add(name, obj);
									str += BitConverter.ToString(obj).ToLower().Replace("-", "");
									str += '.';
									objIndex = 0;
								}
								Console.WriteLine(str);
							}
						}
					}
				}
				foreach (var d in dict)
				{
					Console.WriteLine(d);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("\n" + ex.Message);
			}
			//Console.WriteLine( new String(Encoding.ASCII.GetChars(btsRead)) );
		}

	}
	public class NTSON
	{
		private List<byte> bytes = new List<byte>();
		private byte nameSize;
		public byte[] Bytes
		{
			get => bytes.ToArray();
		}
		public NTSON(byte[] array)
		{
			bytes = new List<byte>(array);
		}
		public void Place(string name, int data)
		{
			byte[] bts = BitConverter.GetBytes(data);
			byte[] nameBts = Encoding.ASCII.GetBytes(name);
			bytes.Add((byte)nameBts.Length);
			bytes.AddRange(nameBts);
			bytes.Add((byte)bts.Length);
			bytes.AddRange(bts);
		}
		public NTSON(byte SizeOf = 1)
		{
			nameSize = SizeOf;
			bytes.AddRange(Encoding.ASCII.GetBytes("_nitison_"));
			bytes.Add(SizeOf);
		}
		//public void Place(string name, )
	}
}
