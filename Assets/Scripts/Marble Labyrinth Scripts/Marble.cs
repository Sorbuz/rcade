using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Marble : MonoBehaviour {
	public Text timer;
	private float time;
	private bool timerRunning;

	Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		timerRunning = false;
	}
	
	// Update is called once per frame
	void Update () {
		// Press space to start
		if (Input.GetKey (KeyCode.Space)) {
			rb.useGravity = true;
			timerRunning = true;
		}

		if (timerRunning) {
			time += Time.deltaTime;
		}

		decimal d1 = (decimal)time;
		decimal rounded = decimal.Round (d1, 1);
		timer.text = "Time: " + rounded.ToString () + " seconds";
	}

	void OnTriggerEnter(Collider other) {
		// Won game
		if (other.gameObject.CompareTag ("Finish")) {
			this.gameObject.SetActive (false);
		}
	}
}
