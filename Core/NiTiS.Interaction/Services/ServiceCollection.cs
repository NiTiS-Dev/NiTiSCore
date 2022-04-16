using NiTiS.Reflection;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

namespace NiTiS.Interaction.Services;

public class ServiceCollection
{
	private readonly ServiceProvider provider = new();
	private readonly List<LoadEntry> entries = new();
	private int gindex = 0;
	public ServiceCollection AddInstance<T>(T itm)
	{
		if (itm is null) throw new ArgumentNullException(nameof(itm));
		gindex++;
		entries.Add(new(gindex, typeof(T), itm));
		return this;
	}
	public ServiceCollection AddSingleton<T>() => AddSingleton<T>(x => new[] { x });
	public ServiceCollection AddSingleton<T>(ArgBuilder argumentBuilder)
	{
		gindex++;
		entries.Add(new(gindex, typeof(T), argumentBuilder));
		return this;
	}
	public ServiceProvider Build()
	{
		IEnumerable<LoadEntry> sortedEntries = entries.OrderBy(x => x.IsInstance ? 0 : 1).ThenBy(x => x.id);
		foreach (LoadEntry entry in sortedEntries)
		{
			if (entry.IsInstance)
			{
				provider.AddService(entry.instance);
			}
			if (entry.IsSingleton)
			{
				entry.TryGenerate(provider);
				provider.AddService(entry.instance);
			}
			if (entry.instance is not null and IService service)
			{
				service.Initialize(provider);
			}
		}
		foreach (object obj in provider.services)
		{
			if (obj is not null and IService service)
			{
				service.PostInitialize(provider);
			}
		}
		return this.provider;
	}
	public delegate object[] ArgBuilder(ServiceProvider provider);
	private struct LoadEntry : IEquatable<LoadEntry>
	{
		public readonly int id;
		public readonly Type type;
		public readonly ArgBuilder? builder;
		public object? instance;
		public bool IsSingleton => this.builder is not null;
		public bool IsInstance => this.instance is not null;
		internal LoadEntry(int id, Type type, ArgBuilder builder)
		{
			this.id = id;
			this.type = type;
			this.instance = null;
			this.builder = builder;
		}
		internal LoadEntry(int id, Type type, object instance)
		{
			this.id = id;
			this.type = type;
			this.instance = instance;
			this.builder = null;
		}
		public void TryGenerate(IServiceProvider provider)
		{
			object? obj = null;
			TypeEditor edit = new(type);
			ConstructorInfo? ctor = edit.GetFreeConstructor();
			if (ctor is null)
			{
				ctor = edit.GetConstructor(CONST_PARAMS);
				obj = ctor?.Invoke(new object[] { provider });
			}
			else
			{
				obj = ctor.Invoke(Array.Empty<object>());
			}
			instance = obj;
		}

		public bool Equals(LoadEntry other) => other.type == this.type;

		public static readonly Type[] CONST_PARAMS = new Type[]
		{
			typeof(IServiceProvider)
		};
	}
}
