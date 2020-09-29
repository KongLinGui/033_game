using UnityEngine;
using System.Collections;
using InaneGames;
public class MusicCreator : MonoBehaviour {
	public static GameObject m_juxeBox; 
	// Use this for initialization
	void Start () {
		if(m_juxeBox==null)
		{
			m_juxeBox = (GameObject)Instantiate(Resources.Load("Music") as GameObject,Vector3.zero,Quaternion.identity);
			DontDestroyOnLoad(m_juxeBox);
		}
	}
	
}
