using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnitySubCore.Pool
{
	/// <summary>
	/// Manage Pool as a Component
	/// </summary>
	public class ComponentPool : MonoBehaviour
	{
		private Dictionary<string, Pool<APoolableMono>> _pools = new Dictionary<string, Pool<APoolableMono>>();

		/// <summary>
		/// Parent of pool gameObject
		/// </summary>
		private Transform _trmParent;

		/// <param name="trmParent">Parent of pool gameObject</param>
		public ComponentPool(Transform trmParent)
		{
			_trmParent = trmParent;
			return ;
		}

		/// <summary>
		/// Create Pool
		/// </summary>
		/// <param name="prefab">Pool gameObject</param>
		/// <param name="count">Initial Pool size</param>
		public void CreatePool(APoolableMono prefab, int count = 10)
		{
			Pool<APoolableMono> pool;

			if (prefab == null)
			{
				USCLogger.LogError($"{nameof(prefab)} cannot be null!");
				throw (new ArgumentNullException(nameof(prefab)));
			}
			pool = new Pool<APoolableMono>(prefab, _trmParent, count);
			_pools.Add(prefab.gameObject.name, pool);
			return ;
		}

		/// <summary>
		/// Get GameObject from pool
		/// </summary>
		/// <param name="prefabName">name of prefab</param>
		/// <returns>monobehaviour of prefab</returns>
		public APoolableMono Pop(string prefabName)
		{
			APoolableMono item;

			if (!_pools.ContainsKey(prefabName))
			{
				USCLogger.LogError($"Prefab does no exist on pool : {prefabName}");
				return (null);
			}
			item = _pools[prefabName].Pop();
			return (item);
		}

		/// <summary>
		/// return GameObject on pool
		/// </summary>
		/// <param name="obj">prefab</param>
		public void Push(APoolableMono obj)
		{
			if (!_pools.ContainsKey(obj.name))
			{
				USCLogger.LogError($"Prefab does no exist on pool : {obj.name}");
				return;
			}
			_pools[obj.name].Push(obj);
			return ;
		}
	}
}
