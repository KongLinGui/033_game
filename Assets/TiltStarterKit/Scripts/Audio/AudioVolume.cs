using UnityEngine;
using System.Collections;

namespace InaneGames {
/// <summary>
/// A simple Audio volume which will change the volume of the audio according to the player prefs.
/// </summary>
	public class AudioVolume : MonoBehaviour {
		/// <summary>
		/// The volume scalar.
		/// </summary>
		public float volScalar = 1f;
		public bool playOnWake;
		
		/// <summary>
		/// Use update -- we probably dont want to use that if the volume is not changing -- IE usually only in main menu
		/// </summary>/
		public bool useUpdate = true;
		void Awake () {
			
			if(GetComponent<AudioSource>())
			{
				GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("AudioVolume",1) * volScalar;

				if(playOnWake && GetComponent<AudioSource>().volume>0)
				{
					GetComponent<AudioSource>().Play();
				}
			}
		}
		
		void Update () {
			if(GetComponent<AudioSource>() && useUpdate)
			{
				GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("AudioVolume",1) * volScalar;
				if(playOnWake && GetComponent<AudioSource>().volume>0 && GetComponent<AudioSource>().isPlaying==false) 
				{
					GetComponent<AudioSource>().Play();
				}
			}
		}
	}
}