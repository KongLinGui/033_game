using UnityEngine;
using System.Collections;

public class GravityChanger : MonoBehaviour {

	public float speed = 2f;//: float = 2.0f;
	private float gravityLerp = 5f;
	public float maxTilt = 20.0f;

	public float smoothingSpeed = 5f;

	public float gravity = -15;
	void FixedUpdate(){

		float zmovment = Input.GetAxis("Horizontal");//-Input.acceleration.y;
		float xmovment = Input.GetAxis("Vertical");//-Input.acceleration.x;
		Vector3 dir = new Vector3(xmovment,0,zmovment);


		if(Application.platform == RuntimePlatform.IPhonePlayer)
		{
			dir = new Vector3(-Input.acceleration.z,0,Input.acceleration.x);

		//	dir.x = Mathf.Lerp(dir.x , -Input.acceleration.z, 1f * Time.deltaTime);
			//dir.z = Mathf.Lerp(dir.z , Input.acceleration.x, 1f * Time.deltaTime);

			if (dir.sqrMagnitude > 1)
				dir.Normalize();

			zmovment = Mathf.Lerp(zmovment,dir.z,.5f * Time.smoothDeltaTime);
			xmovment = Mathf.Lerp(xmovment,dir.x,.5f * Time.smoothDeltaTime);

			//zmovment = dir.z;
		//	xmovment = dir.x;

		}

//		Debug.Log ("xMovement:"+xmovment + "zMovement" + zmovment);

		Vector3 tgravity =new Vector3(zmovment*speed,gravity,xmovment*speed);
		//tgravity = Vector3.Lerp(Physics.gravity,tgravity,gravityLerp*Time.smoothDeltaTime);
		Physics.gravity= tgravity;//new Vector3(zmovment*speed,gravity,xmovment*speed);
		Vector3 vec = Physics.gravity;
		vec.x = -Physics.gravity.z;
		vec.z = Physics.gravity.x;
		vec.y = 0;
		transform.rotation = Quaternion.Euler(vec);
	}

}
