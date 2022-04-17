using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using NiTiS.Collections.Generic;

namespace NiTiS.RawSalt.Registry;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public class RegistryKey<T> : Twosome<Idendifier, T>, IEquatable<Twosome<Idendifier, T>> where T : IEquatable<T>
{
	public Idendifier ID => Left;
	public T Value => Right;
	public RegistryKey(Idendifier id, T item) : base(id, item)
	{
	}

	public override bool Equals(object? obj) => obj is Twosome<Idendifier, T> key && Equals(key);
	public bool Equals(Twosome<Idendifier, T>? other) => other is not null && other.Left == Left && other.Right.Equals(Right);
	public override int GetHashCode()
	{
#if NET48
		int hashCode = -1962484947;
		hashCode = hashCode * -1521134295 + EqualityComparer<Idendifier>.Default.GetHashCode(ID);
		hashCode = hashCode * -1521134295 + EqualityComparer<T>.Default.GetHashCode(Value);
		return hashCode;
#else
		return HashCode.Combine(ID, Value);
#endif
	}
	public static bool operator ==(RegistryKey<T> tzis, Twosome<Idendifier, T> other) => tzis?.Equals(other) ?? false;
	public static bool operator !=(RegistryKey<T> tzis, Twosome<Idendifier, T> other) => !tzis?.Equals(other) ?? true;
	private string GetDebuggerDisplay() => ToString( (id, itm) => $"[{id}|{itm}]" );
}
