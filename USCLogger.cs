using System;
using UnityEngine;

namespace UnitySubCore
{
	/// <summary>
	/// Logger for UnitySubCore
	/// </summary>
	public static class USCLogger
	{
		public static bool enabled = true;

		public static void Log(string msg)
		{
			if (enabled)
				Debug.Log($"[USC] {msg}");
			return ;
		}

		public static void LogWarning(string msg)
		{
			if (enabled)
				Debug.LogWarning($"[USC] {msg}");
			return ;
		}

		public static void LogError(string msg)
		{
			if (enabled)
				Debug.LogError($"[USC] {msg}");
			return ;
		}

		public static void LogException(Exception ex)
		{
			if (enabled)
				Debug.LogException(ex);
			return;
		}
	}
}
