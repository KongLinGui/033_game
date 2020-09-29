using UnityEngine;
using System.Collections;

public class Ballscript : MonoBehaviour {

	private float m_stickyFrames = 5;
	private float m_stickyScalar = 1f;
	public AudioClip ballHitBallAC;
	public AudioClip ballHitWallAC;

	public void Start()
	{
		StickynesScript stickynessScript = (StickynesScript)GameObject.FindObjectOfType(typeof(StickynesScript));
		if(stickynessScript)
		{
			m_stickyScalar = stickynessScript.stickyscalar;
		}
		if(PlayerPrefs.GetFloat("AudioVolume",0)>0)
		{
		
			GetComponent<AudioSource>().volume = transform.GetComponent<Rigidbody>().velocity.magnitude / 20f;
		}
	}
	public void Sticky()
	{
		Debug.Log ("Sticky");
		if(GetComponent<Rigidbody>())
		{
			GetComponent<Rigidbody>().drag = 5 * m_stickyScalar;
			m_stickyFrames = 1f;
		}
	}
	public void LateUpdate()
	{
		if(PlayerPrefs.GetFloat("AudioVolume",0)>0)
		{
			GetComponent<AudioSource>().volume = transform.GetComponent<Rigidbody>().velocity.magnitude / 20f;
		}
		if(m_stickyFrames>0)
		{
			m_stickyFrames-=Time.deltaTime;

		}else{
			GetComponent<Rigidbody>().drag =0;
		}
	}


	public void OnCollisionEnter(Collision col)
	{
		string str = col.collider.gameObject.tag;
		if(str.Contains("Wall"))
		{
			GetComponent<AudioSource>().PlayOneShot(ballHitWallAC);

		}
		if(str.Contains("Ball"))
		{
			GetComponent<AudioSource>().PlayOneShot(ballHitBallAC);
		}

	}
	

}
