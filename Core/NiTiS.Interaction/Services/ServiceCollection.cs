using NiTiS.Reflection;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

namespace NiTiS.Interaction.Services;

public class ServiceCollection
{
	private readonly List<Type> singletonTypes = new();
	private readonly List<object> instances = new();
	public ServiceCollection AddSingleton<T>()
	{
		this.singletonTypes.Add(typeof(T));
		return this;
	}
	public ServiceCollection AddInstance(object instance)
	{
		if (!this.instances.Exists(t => t.GetType() == instance.GetType())) throw new ArgumentException("Element allready exists");
		this.instances.Add(instance);
		return this;
	}
	public ServiceProvider Build() //Its works (maybe), doesnt touch!!
	{
		ServiceProvider provider = new();
		foreach (object instanced in instances)
		{
			provider.AddService(instanced);
		}
		List<Type> allreadyInitialized = new(singletonTypes.Count);
		List<Singleton> singls = new(singletonTypes.Count);
		foreach(Type tp in singletonTypes)
		{
			singls.Add(new(tp));
		}
		void Sort()
		{
			singls = singls
			   .OrderByDescending(s => s.RequiredTypes
				   .All(t => allreadyInitialized.Contains(t)) ? 1 : 0).ToList();
		}
		Sort(); //Sort at start and on every cycle
		while (singls.Count > 0)
		{
			Type type = singls[0].Type;
			singls.RemoveAt(0);
			TypeEditor editor = new(type);
			ConstructorInfo? constr = editor.GetConstructor(new Type[] { typeof(IServiceProvider) });

			object? service = constr?.Invoke(new[] { provider });
			service ??= editor.GetFreeConstructor()?.Invoke(Array.Empty<object>());
			if (service is null)
			{
				throw new ValidConstructorNotFoundException(type);
			}
			provider.AddService(service);
			allreadyInitialized.Add(type);
			Sort();
		}
		foreach (object obj in provider.services)
		{
			InstanceEditor ieditor = new(null, obj.GetType());
			foreach (PropertyInfo i in ieditor.GetProperityEnumerable())
			{
				AutomaticFillAttribute? attr = i.GetCustomAttribute<AutomaticFillAttribute>();
				if (attr is not null && !attr.Type.IsIgnore() && attr.Type.IsValid(AutomaticFill.ServiceProvider))
				{
					Type reqType = i.PropertyType;
					if (provider.TryGetService(reqType, out object? ser))
					{
						i.SetValue(obj, ser);
					}
				}
			}
			foreach (FieldInfo i in ieditor.GetVariableEnumerable())
			{
				AutomaticFillAttribute? attr = i.GetCustomAttribute<AutomaticFillAttribute>();
				if (attr is not null && !attr.Type.IsIgnore() && attr.Type.IsValid(AutomaticFill.ServiceProvider))
				{
					Type reqType = i.FieldType;
					if (provider.TryGetService(reqType, out object? ser))
					{
						i.SetValue(obj, ser);
					}
				}
			}
		}
		return provider;
	}
	private readonly struct Singleton
	{
		public readonly Type Type { get; }
		public Singleton(Type type)
		{
			Type = type;
			InstanceEditor instanceEditor = new(null, type); //Unsafe, i shoud remake this classes in future with mutual class depend
			instanceEditor.Flags = BindingFlags.Instance | BindingFlags.NonPublic; //readonly + private (or maybe +protected idk)
			RequiredTypes = instanceEditor.GetVariableEnumerable().Select(s => s.FieldType).ToArray();
		}
		public readonly Type[] RequiredTypes { get; }
	}
}
