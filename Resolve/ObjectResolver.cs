using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitySubCore.Resolve
{
	/// <summary>
	/// Object Resolver for Unity
	/// </summary>
	public class ObjectResolver
	{
		private readonly HashSet<Type> _registrations = new();
		private readonly Dictionary<Type, object> _cachedInstances = new();

		/// <summary>
		/// Register type
		/// </summary>
		/// <typeparam name="T">Register type</typeparam>
		public void Register<T>()
		{
			_registrations.Add(typeof(T));
			return ;
		}

		/// <summary>
		/// Register type with instance
		/// </summary>
		/// <typeparam name="T">Register type</typeparam>
		public void RegisterInstance<T>(T instance)
		{
			_cachedInstances[typeof(T)] = instance;
			_registrations.Add(instance.GetType());
			return ;
		}

		/// <summary>
		/// Unregister type and instance
		/// </summary>
		/// <typeparam name="T">Unregister type</typeparam>
		public void Unregister<T>()
		{
			_registrations.Remove(typeof(T));
			_cachedInstances.Remove(typeof(T));
			return ;
		}

		/// <summary>
		/// Get instance as T
		/// </summary>
		/// <typeparam name="T">type in resolver</typeparam>
		/// <returns>instance as type</returns>
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
				throw (new InvalidOperationException($"No registration for {type.FullName}"));
			}
			var constructor = type.GetConstructors().First();
			var args = constructor.GetParameters().Select(p => Resolve(p.ParameterType)).ToArray();

			instance = Activator.CreateInstance(type, args);
			_cachedInstances[type] = instance;
			return (instance);
		}
	}
}