using NiTiS.Collections.Generic;

namespace NiTiS.Collections
{
	public static class SingletonManager
	{
		private static volatile HardTypedDictonary? volatileDict;
		private static HardTypedDictonary? localDict;
		public static T? GetInstance<T>(ManagerLocal local = ManagerLocal.Volatile) where T : notnull 
			=> (local == ManagerLocal.Locale ?
				(localDict ??= new()) :
				(volatileDict ??= new()))
				.Get<T>();
		public static void AddInstance<T>(T instance, ManagerLocal local = ManagerLocal.Volatile) where T : notnull 
			=> (local == ManagerLocal.Locale ?
				(localDict ??= new()) :
				(volatileDict ??= new()))
				.Add(instance);
	}
}
