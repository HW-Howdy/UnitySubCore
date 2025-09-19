using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System;
using UnityEditor;

namespace UnitySubCore.Json
{
	public static class SCJson
	{
		private static readonly JsonSerializerSettings settings = new JsonSerializerSettings
		{
			TypeNameHandling = TypeNameHandling.Auto,
		};

		public static void SaveToJson<GType1>(GType1 data, string path, bool isBase64 = false)
		{
			string json;

			if (data == null)
				throw (new ArgumentNullException("data", "data cannot be null!"));
			if (path == "")
				throw (new ArgumentException("json fileName cannot be empty!", "path"));
			path = GetJsonPath(path);
			json = JsonConvert.SerializeObject(data, Formatting.Indented, settings);
			if (isBase64)
				json = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(json));
			File.WriteAllText(path, json);
			return;
		}

		public static GType1 LoadFromJson<GType1>(string path, bool isBase64 = false)
		{
			string json;

			if (path == "")
				throw (new ArgumentException("json fileName cannot be empty!", "path"));
			path = GetJsonPath(path);
			if (!File.Exists(path))
			{
				Debug.LogWarning($"There are no file! : {path}");
				return (default);
			}
			json = File.ReadAllText(path);
			if (isBase64)
				json = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(json));
			return ((GType1)JsonConvert.DeserializeObject(json, typeof(GType1), settings));
		}

		public static bool HasJsonFile(string path, bool isDataPath = false)
		{
			if (!isDataPath)
			{
				path = GetJsonPath(path);
			}
			return (File.Exists(path));
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

#if UNITY_EDITOR
		[MenuItem("SubCore/Open Save Folder")]
		public static void OpenPersistentDataPath()
		{
			EditorUtility.RevealInFinder(Application.persistentDataPath);
			return;
		}
#endif
	}
}