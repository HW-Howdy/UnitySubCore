using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitySubCore.Resolve
{
	public class ObjectResolver
	{
		private readonly HashSet<Type> _registrations = new();
		private readonly Dictionary<Type, object> _cachedInstances = new();

		public void Register<T>()
		{
			_registrations.Add(typeof(T));
			return;
		}

		public void RegisterInstance<T>(T instance)
		{
			_cachedInstances[typeof(T)] = instance;
			_registrations.Add(instance.GetType());
			return;
		}

		public void Unregister<T>()
		{
			_registrations.Remove(typeof(T));
			_cachedInstances.Remove(typeof(T));
			return;
		}

		public T Resolve<T>()
		{
			return ((T)Resolve(typeof(T)));
		}

		private object Resolve(Type type)
		{
			if (_cachedInstances.TryGetValue(type, out var instance))
				return (instance);
			if (!_registrations.Contains(type))
			{
				throw new InvalidOperationException($"No registration for {type.FullName}");
			}
			var constructor = type.GetConstructors().First();
			var args = constructor.GetParameters().Select(p => Resolve(p.ParameterType)).ToArray();

			instance = Activator.CreateInstance(type, args);
			_cachedInstances[type] = instance;
			return (instance);
		}
	}
}