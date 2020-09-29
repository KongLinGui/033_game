using UnityEngine;
using System.Collections;

public class DeathTrigger : MonoBehaviour {
	public float delayBeforeGameOver = 0.5f;

	private static AudioSource K_AUDIOSOURCE;
	private AudioSource m_audioSource;
	public void Start()
	{
		m_audioSource = K_AUDIOSOURCE;
		if(K_AUDIOSOURCE==null)
		{
			GameObject go = new GameObject();
			go.AddComponent<InaneGames.AudioVolume>();
			DontDestroyOnLoad(go);
			m_audioSource = go.AddComponent<AudioSource>();
			m_audioSource.clip = Resources.Load ("Gameover") as AudioClip;
			K_AUDIOSOURCE = m_audioSource;
		}
	}
	public void OnTriggerEnter(Collider col)
	{
		if(col.name.Contains("Ball"))
		{
			Destroy(col.gameObject);
			StartCoroutine(restartLevelIE());

			if(m_audioSource)
			{
				m_audioSource.Play();
			}
		}

	}
	IEnumerator restartLevelIE()
	{
		yield return new WaitForSeconds(delayBeforeGameOver);
		Application.LoadLevel(Application.loadedLevel);
	}


}
