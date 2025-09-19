using UnityEngine;

namespace UnitySubCore.Singleton
{
	public abstract class ASingleton<GType1> where GType1 : class, new()
	{
		private static GType1 _instance;

		private static readonly object _locker = new object();
		private static bool _isDestroyed = false;

		public static GType1 Instance
		{
			get
			{
#if UNITY_EDITOR
				if (!Application.isPlaying)
					return (null);
#endif
				if (_isDestroyed)
				{
					Debug.LogWarning($"Destoryed Singleton : {typeof(GType1).ToString()}");
					return (null);
				}
				lock (_locker)
				{
					if (ASingleton<GType1>._instance == null)
					{
						_instance = new GType1();
					}
				}
				return (_instance);
			}
		}

		private void OnApplicationQuit()
		{
			_isDestroyed = true;
		}
	}
}