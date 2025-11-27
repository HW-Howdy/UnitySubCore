using System.Collections.Generic;

namespace UnitySubCore.StringTable
{
	/// <summary>
	/// StringTable for UnitySubCore
	/// </summary>
	public sealed class USCStringTable : IUSCStringTable
	{
		public string Language { get; private set; }
		private readonly Dictionary<string, string> table;

		public USCStringTable(string language, Dictionary<string, string> data)
		{
			Language = language;
			table = data ?? new Dictionary<string, string>();
			return ;
		}

		public string Get(string key)
		{
			if (table.TryGetValue(key, out string value) )
				return (value);
			USCLogger.LogError($"Unknown Key : {key}");
			return (key);
		}

		public bool Contains(string key)
		{
			return (table.ContainsKey(key));
		}
	}
}