using System;

namespace NiTiS.Interaction.Services;

public static class ServiceProviderExtensions
{
	public static T GetRequiredService<T>(this IServiceProvider provider) => (T)provider.GetService(typeof(T));
}
