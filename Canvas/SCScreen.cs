using UnityEngine;

namespace UnitySubCore.Canvas
{
	public static class SCScreen
	{

		public static void SetResolution(int width, int height)
		{
			int deviceWidth = Screen.width;
			int deviceHeight = Screen.height;

			Screen.SetResolution(width, (int)(((float)deviceHeight / deviceWidth) * width), true);
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