using UnityEngine;
using System.Collections;
namespace PoolKit
	{
	public class MainMenuState : MonoBehaviour {

		public TouchButton2 graphicsQuality;
		public GameObject mainPanel;
		public GameObject optionsPanel;
		public GameObject levelSelect;

		public Texture[] graphicsTextures;

		void Start()
		{
			updateGraphicsQuality();
		}
		public void OnEnable()
		{
			BaseGameManager.onButtonPress += onButtonClickCBF;
		}
		public void OnDisable()
		{
			BaseGameManager.onButtonPress -= onButtonClickCBF;
		}
		public void onButtonClickCBF(string buttonID)
		{
			if(buttonID.Contains("Level"))
			{
				try{
					int levelIndex = int.Parse(buttonID.Substring(5,buttonID.Length-5));
					Application.LoadLevel(levelIndex);
				}catch(UnityException e)
				{
				}
			}
			switch (buttonID) 
			{
			case "Start":
				levelSelect.SetActive(true);
				mainPanel.SetActive(false);
				break;
			case "SelectBack":
				levelSelect.SetActive(false);
				mainPanel.SetActive(true);
				break;


			case "Options":
				optionsPanel.SetActive(true);
				mainPanel.SetActive(false);
				break;

			case "OptionsBack":
				Debug.Log ("optionsBack");
				optionsPanel.SetActive(false);
				mainPanel.SetActive(true);
				break;
				
			case "GraphicsToggle":
				toggleQuality();
				break;
			}
		}


		public void toggleQuality()
		{
			int currentQuality = QualitySettings.GetQualityLevel();

			if(currentQuality==0)
			{
				QualitySettings.SetQualityLevel(1);		
			}
			else if(currentQuality==1)
			{
				QualitySettings.SetQualityLevel(2);		
			}
			else if(currentQuality==2)
			{
				QualitySettings.SetQualityLevel(0);		
			}
			Debug.Log ("toggleQuality" + QualitySettings.GetQualityLevel() + " oldquality " + currentQuality);
			updateGraphicsQuality();
		}

		void updateGraphicsQuality()
		{
			if(graphicsQuality)
			{
				graphicsQuality.setTexture(graphicsTextures[QualitySettings.GetQualityLevel()]);// = "Graphics: "+ QualitySettings.names[QualitySettings.GetQualityLevel()];
			}
		}
	}

}