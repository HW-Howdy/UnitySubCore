using System;
using System.Collections.Generic;

namespace UnitySubCore.EventBus
{
	/// <summary>
	/// EventBus using struct param
	/// </summary>
	public class EventBus
	{
		private readonly Dictionary<Type, List<Delegate>> eventDic = new Dictionary<Type, List<Delegate>>();

		/// <summary>
		/// Subscribe Delegate on EventBus
		/// </summary>
		/// <typeparam name="GType01">IUSCEvent struct recomanded</typeparam>
		public void Subscribe<GType01>(Action<GType01> handler) where GType01 : IUSCEvent
		{
			Type type = typeof(GType01);

			if (!eventDic.TryGetValue(type, out List<Delegate> list))
			{
				list = new List<Delegate>();
				eventDic[type] = list;
			}
			list.Add(handler);
			return ;
		}

		/// <summary>
		/// Unsubscribe Delegate on EventBus
		/// </summary>
		/// <typeparam name="GType01">IUSCEvent struct recomanded</typeparam>
		public void Unsubscribe<GType01>(Action<GType01> handler) where GType01 : IUSCEvent
		{
			Type type = typeof(GType01);

			if (eventDic.ContainsKey(type))
			{
				eventDic[type].Remove(handler);
				if (eventDic[type].Count == 0)
					eventDic.Remove(type);
			}
			return ;
		}

		/// <summary>
		/// Publish Event by type
		/// </summary>
		/// <typeparam name="GType01">Event trigger type</typeparam>
		public void Publish<GType01>(GType01 evt) where GType01 : IUSCEvent
		{
			Type type = typeof(GType01);
			List<Delegate> list;

			if (!eventDic.TryGetValue(type, out list))
				return ;
			for (int i = 0; i < list.Count; i++)
			{
				try
				{
					((Action<GType01>)list[i])?.Invoke(evt);
				}
				catch (Exception e)
				{
					USCLogger.LogException(e);
				}
			}
			return ;
		}
	}
}