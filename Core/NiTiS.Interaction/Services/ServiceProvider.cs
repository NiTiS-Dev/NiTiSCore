using NiTiS.Collections.Generic;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace NiTiS.Interaction.Services;

public class ServiceProvider : IServiceProvider, IDisposable
{
	internal readonly HardTypedDictonary services = new();
	public T GetService<T>(Type serviceType) => (T)GetService(serviceType);
	public object GetService(Type serviceType)
	{
		object? service = this.services.Get(serviceType);
		return service ?? throw new Exception("Service not found");
	}
	public bool TryGetService(Type serviceType,	
		#if NITIS_NULL_ANN
		[NotNullWhen(true)] 
		#endif
		out object? service)
	{
		if (services.Exists(serviceType))
		{
			service = this.services.Get(serviceType);
#pragma warning disable CS8762 // Параметр должен иметь значение, отличное от NULL, при выходе в определенном состоянии.
			return true;
#pragma warning restore CS8762 // Параметр должен иметь значение, отличное от NULL, при выходе в определенном состоянии.
		}
		else
		{
			service = null;
		}
		return false;
	}
	public bool TryGetService<T>(
		#if NITIS_NULL_ANN
		[NotNullWhen(true)]
		#endif
		out T? service)
	{
		if (services.Exists<T>())
		{
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
#pragma warning disable CS8631 // Тип не может быть использован как параметр типа в универсальном типе или методе. Допустимость значения NULL для аргумента типа не соответствует типу ограничения.
			service = this.services.Get<T>();
#pragma warning restore CS8631 // Тип не может быть использован как параметр типа в универсальном типе или методе. Допустимость значения NULL для аргумента типа не соответствует типу ограничения.
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
#pragma warning disable CS8762 // Параметр должен иметь значение, отличное от NULL, при выходе в определенном состоянии.
			return true;
#pragma warning restore CS8762 // Параметр должен иметь значение, отличное от NULL, при выходе в определенном состоянии.
		}
		else
		{
			service = default;
		}
		return false;
	}
	public bool Exists<T>() => this.services.Exists<T>();
	public bool Exists(Type serviceType) => this.services.Exists(serviceType);
	public void AddService<T>(T service) => services.Add(service);
	internal void AddService(Type type, object service) => services.Add(type, service);
	public void Dispose()
	{
		foreach(IDisposable disp in services.Where(serv => serv is IDisposable).Cast<IDisposable>())
		{
			disp.Dispose();
		}
	}
}
