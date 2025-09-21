using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UnitySubCore.Canvas
{
	public static class SCScreen
	{
		private static Vector2Int referenceResolution = new Vector2Int(1920, 1080);

		[RuntimeInitializeOnLoadMethod]
		static void Init()
		{
			SceneManager.sceneLoaded += OnSceneLoaded;
			return ;
		}

		private static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
			CanvasScaler[] array = GameObject.FindObjectsOfType<CanvasScaler>();

			for (int i = 0; i < array.Length; i++)
			{
				CanvasScaler scaler = array[i];

				scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
				scaler.referenceResolution = referenceResolution;
			}
			return ;
		}

		public static void SetReferenceResolution(Vector2Int resolution)
		{
			SetReferenceResolution(resolution.x, resolution.y);
			return ;
		}

		public static void SetReferenceResolution(int width, int height)
		{
			CanvasScaler[] array = GameObject.FindObjectsOfType<CanvasScaler>();

			referenceResolution = new Vector2Int(width, height);
			for (int i = 0; i < array.Length; i++)
			{
				array[i].referenceResolution = referenceResolution;
			}
			return ;
		}

		public static void SetResolution(int width, int height, FullScreenMode mode)
		{
			Screen.SetResolution(width, height, mode);
			SetReferenceResolution(width, height);
			Camera.main.rect = new Rect(0, 0, 1, 1);
			return ;
		}

		public static void SetFixedResolution(int width, int height, FullScreenMode mode)
		{
			int deviceWidth = Screen.width;
			int deviceHeight = Screen.height;

			Screen.SetResolution(width, (int)(((float)deviceHeight / deviceWidth) * width), mode);
			if ((float)width / height < (float)deviceWidth / deviceHeight)
			{
				float newWidth = ((float)width / height) / ((float)deviceWidth / deviceHeight);
				Camera.main.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f);
			}
			else
			{
				float newHeight = ((float)deviceWidth / deviceHeight) / ((float)width / height);
				Camera.main.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight);
			}
			return ; 
		}
	}
}