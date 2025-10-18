using UnityEngine;

namespace UnitySubCore.Pool
{
	/// <summary>
	/// Poolable MonoBehaviours
	/// </summary>
	public abstract class APoolableMono : MonoBehaviour
	{
		public abstract void ResetItem();
	}
}
