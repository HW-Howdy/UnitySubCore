using System.Collections.Generic;
using UnityEngine;

namespace UnitySubCore.Pool
{
	public class Pool<GType1> where GType1 : APoolableMono
	{
		private Stack<GType1> _pool = new Stack<GType1>();
		private GType1 _prefab;
		private Transform _parent;

		public Pool(GType1 prefab, Transform parent, int count = 10)
		{
			_prefab = prefab;
			_parent = parent;

			for (int i = 0; i < count; i++)
			{
				GType1 obj = GameObject.Instantiate(_prefab, _parent);

				obj.gameObject.name = obj.gameObject.name.Replace("(Clone)", "");
				obj.gameObject.SetActive(false);
				_pool.Push(obj);
			}
			return ;
		}

		public GType1 Pop()
		{
			GType1 obj = null;

			if (_pool.Count <= 0)
			{
				obj = GameObject.Instantiate(_prefab, _parent);
				obj.gameObject.name = obj.gameObject.name.Replace("(Clone)", "");
			}
			else
			{
				obj = _pool.Pop();
				obj.gameObject.SetActive(true);
				obj.ResetItem();
			}
			return (obj);
		}

		public void Push(GType1 obj)
		{
			obj.gameObject.SetActive(false);
			_pool.Push(obj);
			return ;
		}
	}
}
