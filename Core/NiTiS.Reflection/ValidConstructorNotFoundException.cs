using System;

namespace NiTiS.Reflection;

public sealed class ValidConstructorNotFoundException : Exception
{
	public Type RequiredType { get; }
	public ValidConstructorNotFoundException(Type type) => RequiredType = type;
	public override string Message => $"Required constructor of type {RequiredType.FullName} not found";
}
