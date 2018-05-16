using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Marble : MonoBehaviour {
	public Text timer;
	private float time;
	private bool timerRunning;

	public Highscore hs;
	GameObject hsO;
	Rigidbody rb;

	void Start () 
	{
		hsO = GameObject.Find ("Menu");
		hsO.SetActive (false);
		rb = GetComponent<Rigidbody> ();
		timerRunning = false;
	}

	void Update () 
	{
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

	void OnTriggerEnter(Collider other) 
	{
		// Won game
		if (other.gameObject.CompareTag ("Finish")) {
			EndGame ();
		}

		if (other.gameObject.CompareTag ("Crystal")) {
			Destroy (gameObject);
		}
	}

	void EndGame () 
	{
		hsO.SetActive (true);
		timerRunning = false;
		hs.SetTime (time);
	}
}
