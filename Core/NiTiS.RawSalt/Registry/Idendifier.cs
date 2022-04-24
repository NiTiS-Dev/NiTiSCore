using NiTiS.Additions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace NiTiS.RawSalt.Registry;

public class Idendifier : IEquatable<string>, IEquatable<Idendifier>
{
	public const string GLOBAL_SPACE = "global";
	public const char SPACE_SPLITERATOR = ':';
	public const char ID_SPLITERATOR = '/';
	private readonly string space, id;
	public static readonly Idendifier NULL;
	private Idendifier()
	{
		this.space = "\0";
		this.id = "";
	}
	public Idendifier(string space, params string[] id)
	{
		if (String.IsNullOrWhiteSpace(space))
		{
			throw new ArgumentNullException(nameof(id));
		}
		string[] paths = id.Select(s => !String.IsNullOrWhiteSpace(s) ? s.Replace(ID_SPLITERATOR, '.') : "").ToArray();
		if (paths.Length <= 0)
		{
			throw new ArgumentNullException(nameof(id));
		}
		this.space = space;
		this.id = Strings.FromArray(paths, "", "", ID_SPLITERATOR.ToString());
	}
	public Idendifier(string space, string id)
	{
		if (String.IsNullOrWhiteSpace(space))
		{
			throw new ArgumentNullException(nameof(id));
		}
		if (String.IsNullOrWhiteSpace(id))
		{
			throw new ArgumentNullException(nameof(space));
		}
		this.id = id;
		this.space = space;
	}
	internal Idendifier(string id)
	{
		if (String.IsNullOrWhiteSpace(id))
		{
			throw new ArgumentNullException(nameof(space));
		}
		this.space = GLOBAL_SPACE;
		this.id = id;
	}
	public static bool IsNull(Idendifier id) => id is null || id.space == "\0";
	public bool Equals(string? other) => ToString() == other && space != "\0" && !other.StartsWith("\0");
	public bool Equals(Idendifier? other) => (space, id) == (other?.space, other?.id) && space != "\0" && other?.space != "\0";

	public override bool Equals(object? obj) => obj is Idendifier idendifier ? Equals(idendifier) : obj is string str && Equals(str);
	public override string ToString() => $"{space}{SPACE_SPLITERATOR}{id}";
	public override int GetHashCode()
	{
#if NET48
		int hashCode = -1962484947;
		hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.space);
		hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.id);
		return hashCode;
#else
		return HashCode.Combine(this.space, this.id);
#endif
	}

	public static bool operator ==(Idendifier tzis, Idendifier other) => tzis?.Equals(other) ?? false;
	public static bool operator !=(Idendifier tzis, Idendifier other) => !tzis?.Equals(other) ?? true;

	static Idendifier() => NULL = new();
}
