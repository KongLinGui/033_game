using UnityEngine;
using System.Collections;

public class ResultsState : MonoBehaviour {

	public GUIText timeLabel;


	public float resultsDelayTime = 1f;
	public GameObject resultsPanel;

	public AudioClip swooshInAC;
	public AudioClip starAC;


	public void show(float t0)
	{
		Debug.Log ("handleVictory1");

		StartCoroutine(showResultsIE(t0));
	}

	IEnumerator showResultsIE(float t0)
	{
		yield return new WaitForSeconds(resultsDelayTime);
		setStats((int)t0);
		
		if(resultsPanel)
			resultsPanel.SetActive(true);



	}
	public void OnEnable()
	{
		PoolKit.BaseGameManager.onButtonPress +=onButtonPress;
	}
	public void OnDisable()
	{
		PoolKit.BaseGameManager.onButtonPress -=onButtonPress;
	}
	public void onButtonPress( string id)
	{
		if(GetComponent<AudioSource>())
		{
			GetComponent<AudioSource>().Play();
		}

		if(id.Equals("Restart"))
		{
			Time.timeScale = 1;

			Application.LoadLevel(Application.loadedLevel);
		}
		if(id.Equals("Next"))
		{
			Time.timeScale = 1;

			Application.LoadLevel(Application.loadedLevel+1);
		}
		if(id.Equals("Main"))
		{
			Time.timeScale = 1;

			Application.LoadLevel(0);
		}
	}

	public void setStats(int time)
	{

		string minSec = string.Format("{0}:{1:00}", time / 60, 
		                              (Mathf.Abs(time)) % 60);

		if(timeLabel)
			timeLabel.text 	= "Time " + minSec;

		if(time < PlayerPrefs.GetFloat("LevelTime" + Application.loadedLevel,99f))
		{
			PlayerPrefs.SetFloat("LevelTime",time);
			PlayerPrefs.SetString("BestTime"+Application.loadedLevel,minSec);

		}

	}
}
