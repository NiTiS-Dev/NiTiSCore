namespace NiTiS.IO;
public readonly struct MemorySize : IEquatable<MemorySize>, IEquatable<long>, IComparable<MemorySize>, IComparable<long>, IFormattable
{
	public readonly long bytes;
	public static MemorySize Zero => new(0);
	public static MemorySize Byte => new(1);

	public static MemorySize Kilobyte => new(1, SizeFormat.Kilobyte);
	public static MemorySize Megabyte => new(1, SizeFormat.Megabyte);
	public static MemorySize Gigabyte => new(1, SizeFormat.Gigabyte);
	public static MemorySize Terabyte => new(1, SizeFormat.Terabyte);

	public static MemorySize Kibibyte => new(1, SizeFormat.Kibibyte);
	public static MemorySize Mebibyte => new(1, SizeFormat.Mebibyte);
	public static MemorySize Gibibyte => new(1, SizeFormat.Gibibyte);
	public static MemorySize Tebibyte => new(1, SizeFormat.Tebibyte);
	public MemorySize(long bytes)
	{
		if (bytes < 0) throw new Exception("File size are invalid");
		this.bytes = bytes;
	}
	public MemorySize(long size, SizeFormat format) : this((long)ToBytes(size, format)) { }
	public override string ToString()
		=> ToString(GetByFormat(SizeFormat.Byte).ToString());
	public decimal GetByFormat(SizeFormat format) 
		=> format switch
	{
		SizeFormat.Bit => bytes * 8,
		SizeFormat.Kilobyte => bytes / (decimal)1_000,
		SizeFormat.Megabyte => bytes / (decimal)1_000_000,
		SizeFormat.Gigabyte => bytes / (decimal)1_000_000_000,
		SizeFormat.Terabyte => (decimal)bytes / 1_000_000_000_000,

		SizeFormat.Kibibyte => bytes / (decimal)1_024,
		SizeFormat.Mebibyte => bytes / (decimal)Math.Pow(1024, 2),
		SizeFormat.Gibibyte => bytes / (decimal)Math.Pow(1024, 3),
		SizeFormat.Tebibyte => bytes / (decimal)Math.Pow(1024, 4),
		_ => bytes
	};
	public static decimal GetByFormat(long bytes, SizeFormat format)
		=> format switch
		{
			SizeFormat.Bit => bytes * 8,
			SizeFormat.Kilobyte => bytes / (decimal)1_000,
			SizeFormat.Megabyte => bytes / (decimal)1_000_000,
			SizeFormat.Gigabyte => bytes / (decimal)1_000_000_000,
			SizeFormat.Terabyte => (decimal)bytes / 1_000_000_000_000,

			SizeFormat.Kibibyte => bytes / (decimal)1_024,
			SizeFormat.Mebibyte => bytes / (decimal)Math.Pow(1024, 2),
			SizeFormat.Gibibyte => bytes / (decimal)Math.Pow(1024, 3),
			SizeFormat.Tebibyte => bytes / (decimal)Math.Pow(1024, 4),
			_ => bytes
		};
	public static decimal ToBytes(long size, SizeFormat format)
		=> format switch
		{
			SizeFormat.Bit => size / 8,
			SizeFormat.Kilobyte => size * (decimal)1_000,
			SizeFormat.Megabyte => size * (decimal)1_000_000,
			SizeFormat.Gigabyte => size * (decimal)1_000_000_000,
			SizeFormat.Terabyte => (decimal)size * 1_000_000_000_000,

			SizeFormat.Kibibyte => size * (decimal)1_024,
			SizeFormat.Mebibyte => size * (decimal)Math.Pow(1024, 2),
			SizeFormat.Gibibyte => size * (decimal)Math.Pow(1024, 3),
			SizeFormat.Tebibyte => size * (decimal)Math.Pow(1024, 4),
			_ => size
		};
	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// 1 KiB => 2^10 (1024) <br/>
	/// 1 KB  => 10^3 (1000) <br/>
	/// <a href="https://en.wikipedia.org/wiki/Byte#Multiple-byte_units">Wiki page about KB size</a>
	/// </remarks>
	/// <param name="format"></param>
	/// <returns></returns>
	public string ToString(string? format)
	{
		format ??= "B";
		decimal dec = format switch
		{
			"B" => GetByFormat(SizeFormat.Byte),

			"kB" or "KB" => GetByFormat(SizeFormat.Kilobyte),
			"MB" => GetByFormat(SizeFormat.Megabyte),
			"GB" => GetByFormat(SizeFormat.Gigabyte),
			"TB" => GetByFormat(SizeFormat.Terabyte),

			"KiB" => GetByFormat(SizeFormat.Kibibyte),
			"MiB" => GetByFormat(SizeFormat.Mebibyte),
			"GiB" => GetByFormat(SizeFormat.Gibibyte),
			"TiB" => GetByFormat(SizeFormat.Tebibyte),
			_ => throw new ArgumentException("Unknown format"),
		};
		return dec.ToString();
	}
	public string ToString(string? format, IFormatProvider? formatProvider)
		=> ToString(format);
	public override bool Equals(object? obj)
		=> obj is not null && (obj is MemorySize ms ? Equals(ms) : obj is long lg ? Equals(lg) : false);
	public bool Equals(long bytes)
		=> this.bytes == bytes;
	public bool Equals(MemorySize size)
		=> this.bytes == size.bytes;
	public int CompareTo(long other)
		=> this.bytes.CompareTo(other);
	public int CompareTo(MemorySize other) 
		=> this.bytes.CompareTo(other.bytes);

	public override int GetHashCode() 
		=> bytes.GetHashCode();

	public static bool operator ==(MemorySize left, MemorySize right)
		=> left.Equals(right);

	public static bool operator !=(MemorySize left, MemorySize right)
		=> !(left == right);

	public static bool operator <(MemorySize left, MemorySize right)
		=> left.CompareTo(right) < 0;

	public static bool operator <=(MemorySize left, MemorySize right)
		=> left.CompareTo(right) <= 0;

	public static bool operator >(MemorySize left, MemorySize right)
		=> left.CompareTo(right) > 0;

	public static bool operator >=(MemorySize left, MemorySize right)
		=> left.CompareTo(right) >= 0;
	public static bool operator ==(MemorySize left, long right)
		=> left.Equals(right);

	public static bool operator !=(MemorySize left, long right)
		=> !(left == right);

	public static bool operator <(MemorySize left, long right)
		=> left.CompareTo(right) < 0;

	public static bool operator <=(MemorySize left, long right)
		=> left.CompareTo(right) <= 0;

	public static bool operator >(MemorySize left, long right)
		=> left.CompareTo(right) > 0;

	public static bool operator >=(MemorySize left, long right)
		=> left.CompareTo(right) >= 0;
	public static MemorySize operator *(MemorySize left, double right)
		=> new( (long)(left.bytes * right));
	public static MemorySize operator /(MemorySize left, double right)
		=> new((long)(left.bytes / right));
	public static MemorySize operator ++(MemorySize left)
		=> new(left.bytes + 1);
	public static MemorySize operator --(MemorySize left)
		=> new(left.bytes - 1);
	public static MemorySize operator +(MemorySize left, long right)
		=> new(left.bytes + right);
	public static MemorySize operator -(MemorySize left, long right)
		=> new(left.bytes - right);
	public static MemorySize operator +(MemorySize left, MemorySize right)
		=> new(left.bytes + right.bytes);
	public static MemorySize operator -(MemorySize left, MemorySize right)
		=> new(left.bytes - right.bytes);
}
