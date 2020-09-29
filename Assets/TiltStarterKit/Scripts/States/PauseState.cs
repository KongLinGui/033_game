using UnityEngine;
using System.Collections;

public class PauseState : MonoBehaviour {
	public GameObject pauseMenu;
	public void OnEnable()
	{
		PoolKit.BaseGameManager.onButtonPress +=onButtonPress;
	}
	public void OnDisable()
	{
		PoolKit.BaseGameManager.onButtonPress -=onButtonPress;
	}
	void toggleAudio()
	{
		Debug.Log ("toggleAudio"+PlayerPrefs.GetFloat("AudioVolume",0));
		if(PlayerPrefs.GetFloat("AudioVolume",0)==0)
		{
			PlayerPrefs.SetFloat("AudioVolume",1f);
		}else{
			PlayerPrefs.SetFloat("AudioVolume",0f);
		}
	}
	public void onButtonPress( string id)
	{
		Debug.Log ("onButtonPress"+id);
		if(GetComponent<AudioSource>())
		{
			GetComponent<AudioSource>().Play();
		}
		if(id.Equals("AudioToggle"))
		{
			toggleAudio();
			Debug.Log ("onButtonPressAudioTogleXXX");

		}
		if(id.Equals("Pause"))
		{
			if(Time.timeScale==0)
			{
				Time.timeScale = 1;
				pauseMenu.SetActive(false);
			}else{
				Time.timeScale = 0;
				pauseMenu.SetActive(true);
			}

		}

		if(id.Equals("Next"))
		{
			Application.LoadLevel(Application.loadedLevel+1);
		}
		if(id.Equals("UnPause"))
		{
			pauseMenu.SetActive(false);
			Time.timeScale = 1;
			Application.LoadLevel(Application.loadedLevel);
		}
	}
	

}
