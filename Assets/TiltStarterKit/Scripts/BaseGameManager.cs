using UnityEngine;
using System.Collections;

namespace PoolKit
{
	public class BaseGameManager
	{
		//an event that listens for when its your turn


		//called when the button is pressed
		public delegate void OnButtonPress(string buttonID);
		public static event OnButtonPress onButtonPress;
		public static void buttonPress(string buttonID)
		{
			if(onButtonPress!=null)
			{
				onButtonPress(buttonID);
			}
		}
	}
}
