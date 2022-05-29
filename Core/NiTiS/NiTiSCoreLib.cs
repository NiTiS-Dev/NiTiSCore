using System.Reflection;

namespace NiTiS.Core;

public static class NiTiSCoreLib
{
	public static readonly Assembly[] BasicLibs =
	{
#nullable disable
		Assembly.GetAssembly(typeof(NiTiSCoreLib)),
		Assembly.GetAssembly(typeof(Additions.EnumInfo)),
		Assembly.GetAssembly(typeof(Collections.SingletonManager)),
		Assembly.GetAssembly(typeof(Interaction.Result)),
		Assembly.GetAssembly(typeof(IO.File)),
		Assembly.GetAssembly(typeof(Math.Comparer)),
		Assembly.GetAssembly(typeof(Reflection.ValidConstructorNotFoundException))
#nullable restore
    };
}
