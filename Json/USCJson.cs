using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System;
using UnityEditor;

namespace UnitySubCore.Json
{
	/// <summary>
	/// Json's save and load class
	/// </summary>
	public static class USCJson
	{
		private static readonly JsonSerializerSettings settings = new JsonSerializerSettings
		{
			TypeNameHandling = TypeNameHandling.Auto,
		};

		/// <summary>
		/// save data as json
		/// </summary>
		/// <typeparam name="GType1">any type you want to save</typeparam>
		/// <param name="data">any data you want to save</param>
		/// <param name="path">json name (can include directory)</param>
		/// <param name="isBase64">incoding base64</param>
		public static void SaveToJson<GType1>(GType1 data, string path, bool isBase64 = false)
		{
			string json;
			string dir;

			if (data == null)
				throw (new ArgumentNullException("data", "data cannot be null!"));
			if (path == "")
				throw (new ArgumentException("json fileName cannot be empty!", "path"));
			path = GetJsonPath(path);
			dir = Path.GetDirectoryName(path);
			if (!Directory.Exists(dir))
				Directory.CreateDirectory(dir);
			json = JsonConvert.SerializeObject(data, Formatting.Indented, settings);
			if (isBase64)
				json = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(json));
			File.WriteAllText(path, json);
			return;
		}

		/// <summary>
		/// load data from json
		/// </summary>
		/// <typeparam name="GType1">any type you want to load</typeparam>
		/// <param name="path">json name (can include directory)</param>
		/// <param name="isBase64">incoding base64</param>
		/// <returns>data as GType1</returns>
		public static GType1 LoadFromJson<GType1>(string path, bool isBase64 = false)
		{
			string json;

			if (path == "")
				throw (new ArgumentException("json fileName cannot be empty!", "path"));
			path = GetJsonPath(path);
			if (!File.Exists(path))
			{
				USCLogger.LogWarning($"There are no file! : {path}");
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
		[MenuItem("USC/Open Save Folder")]
		public static void OpenPersistentDataPath()
		{
			EditorUtility.RevealInFinder(Application.persistentDataPath);
			return;
		}
#endif
	}
}