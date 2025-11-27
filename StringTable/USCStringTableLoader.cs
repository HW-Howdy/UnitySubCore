using System.IO;
using UnityEngine;
using Newtonsoft.Json;

namespace UnitySubCore.StringTable
{
	/// <summary>
	/// StringTable Loader for UnitySubCore
	/// </summary>
	public static class USCStringTableLoader
	{
		public static USCStringTable LoadFromJson(string fileName, string language)
		{
			string json;
			USCStringTable table;

			fileName = GetJsonPath(fileName);
			if (!File.Exists(fileName))
			{
				throw new FileNotFoundException($"StringTable file not found: {fileName}");
			}
			json = File.ReadAllText(fileName);
			table = (USCStringTable)JsonConvert.DeserializeObject(json, typeof(USCStringTable));
			return (table);
		}

		public static string GetJsonPath(string fileName)
		{
			string result;

#if UNITY_EDITOR
			result = Path.Combine(Application.persistentDataPath, fileName + " (Editor).json");
#else
			result = Path.Combine(Application.persistentDataPath, fileName + ".json");
#endif
			return (result);
		}
	}
}