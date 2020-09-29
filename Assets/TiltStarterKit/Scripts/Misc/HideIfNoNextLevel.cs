using UnityEngine;
using System.Collections;

public class HideIfNoNextLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(Application.loadedLevel+1 >= Application.levelCount)
		{
			gameObject.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
