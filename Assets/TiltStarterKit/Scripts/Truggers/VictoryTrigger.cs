using UnityEngine;
using System.Collections;

public class VictoryTrigger : MonoBehaviour {
	public GameObject particleEffect;
	public float radius = 5;
	public Color gizmocolor = new Color(0,0.5f,0,0.5f);
	void OnDrawGizmos() {
		Gizmos.color = gizmocolor;
		Gizmos.DrawSphere(transform.position, radius);
	}
	public PhysicMaterial ballMAT;
	public PhysicMaterial goalMAT;
	public void Awake()
	{
		ballMAT = Resources.Load ("BallMAT") as PhysicMaterial;
		goalMAT = Resources.Load ("GoalMAT") as PhysicMaterial;

		if(particleEffect)	
			particleEffect.SetActive(false);
	}
	public bool containsBall()
	{
		bool hasBall = false;
		Collider[] col = Physics.OverlapSphere(transform.position,radius);
		for(int i=0; i<col.Length; i++)
		{
			if(col[i].name.Contains("Ball"))
			{
				if(col[i] && col[i].GetComponent<Rigidbody>())
				{
					col[i].gameObject.SendMessage("Sticky",SendMessageOptions.DontRequireReceiver);
				}

				//col[i].rigidbody.drag = 5;
				if(particleEffect)	
					particleEffect.SetActive(true);
				hasBall = true;
			}else{
				//i/f(col[i].rigidbody)
				//	col[i].rigidbody.drag = 0;

				if(particleEffect)	
				particleEffect.SetActive(false);
			}
		}
		if(hasBall)
		{
			if(GetComponent<AudioSource>() && GetComponent<AudioSource>().isPlaying==false)
				GetComponent<AudioSource>().Play();
		}else{
			if(GetComponent<AudioSource>())
			{
				GetComponent<AudioSource>().Stop();
			}
		}
		return hasBall;
	}

}
