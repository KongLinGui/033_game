using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour {
	private VictoryTrigger [] m_triggers;
	private bool m_gameOver=false;
	public AudioClip victoryAC;
	private ResultsState m_resultState;
	public Material material;
	void Start () {
		m_triggers = (VictoryTrigger[])GameObject.FindObjectsOfType(typeof(VictoryTrigger));
		StartCoroutine(checkForVictory());
		m_resultState = (ResultsState)GameObject.FindObjectOfType(typeof(ResultsState));


		GameObject planeObject = GameObject.Find("Plane");
		if(planeObject)
		{
			int floorIndex = PlayerPrefs.GetInt("TableIndex",0);

			//if(floorIndex>1)
			{
				if(material)
				{
					Texture tex = Resources.Load("Wall" + PlayerPrefs.GetInt("TableIndex",0)) as Texture;
					material.SetTexture("_MainTex" , tex);
				}
			}

			if(floorIndex>0)
			{
				planeObject.GetComponent<Renderer>().material = Resources.Load("Floor" + PlayerPrefs.GetInt("TableIndex",0)) as Material;
			}
		}
		Application.targetFrameRate = 60;
	}

	IEnumerator checkForVictory()
	{
		yield return new WaitForSeconds(0.125f);
		bool victory = true;
		for(int i=0; i<m_triggers.Length; i++)
		{
			if(m_triggers[i].containsBall()==false)
			{
				victory=false;
				//Debug.Log ("Victory");
			}
		}
		if(victory)
		{
			handleVictory();
			//Application.LoadLevel(Application.loadedLevel+1);
		}
		StartCoroutine(checkForVictory());
	}

	void handleVictory()
	{
		if(m_gameOver)
		{
			return;
		}
		m_gameOver = true;

		Debug.Log ("handleVictory");
		if(m_resultState)
		{
			if(GetComponent<AudioSource>())
			{
				GetComponent<AudioSource>().PlayOneShot(victoryAC);
			
			}
			Debug.Log ("handleVictory1");

			m_resultState.show(Time.timeSinceLevelLoad);
		}
	}
}
