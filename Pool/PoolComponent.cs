using System.Collections.Generic;
using UnityEngine;

namespace UnitySubCore.Pool
{
	public class PoolComponent : MonoBehaviour
	{
		private Dictionary<string, Pool<APoolableMono>> _pools = new Dictionary<string, Pool<APoolableMono>>();

		private Transform _trmParent;

		public PoolComponent(Transform trmParent)
		{
			_trmParent = trmParent;
			return ;
		}

		public void CreatePool(APoolableMono prefab, int count = 10)
		{
			Pool<APoolableMono> pool = new Pool<APoolableMono>(prefab, _trmParent, count);

			_pools.Add(prefab.gameObject.name, pool);
			return ;
		}

		public APoolableMono Pop(string prefabName)
		{
			APoolableMono item;
			if (!_pools.ContainsKey(prefabName))
			{
				Debug.LogError($"Prefab does no exist on pool : {prefabName}");
				return (null);
			}
			item = _pools[prefabName].Pop();
			return (item);
		}

		public void Push(APoolableMono obj)
		{
			_pools[obj.name].Push(obj);
			return ;
		}
	}
}
