using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	
	public float speed = 6f;
	public float turnSpeed = 10.0f;
	float tilt = -20.0f;

	Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		float tiltZ = Input.GetAxis ("Horizontal") * tilt ;
		float tiltX = 0f;//Input.GetAxis ("Vertical") * tilt;

		Quaternion target = Quaternion.Euler (tiltX, 0, tiltZ);

		transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * turnSpeed);
		transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
	}

	void FixedUpdate () {
		rb.velocity = new Vector3 (Input.GetAxis ("Horizontal") * speed, Input.GetAxis ("Vertical") * speed, 0);

	}
}
