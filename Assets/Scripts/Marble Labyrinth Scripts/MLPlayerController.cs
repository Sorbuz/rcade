using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MLPlayerController : MonoBehaviour {
	float tilt = 20.0f;
	float smooth = 5.0f;
	// Use this for initialization
	void Start () {
		Update ();
	}
	
	// Update is called once per frame
	void Update () {
		float tiltZ = Input.GetAxis ("Horizontal") * tilt;
		float tiltX = Input.GetAxis ("Vertical") * tilt;

		Quaternion target = Quaternion.Euler (tiltX, 0, tiltZ);

		transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);
	}
}
