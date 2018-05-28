using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Marble : MonoBehaviour {
	public Text timer;
	public GameObject discharge;
	public GameObject finishOrb;
	public Highscore hs;

	float time;
	bool timerRunning;
	AudioSource timerTick;
	GameObject hsO;
	Rigidbody rb;
	bool isPlaying;

	void Start () 
	{
		hsO = GameObject.Find ("Menu");
		hsO.SetActive (false);
		rb = GetComponent<Rigidbody> ();
		timerRunning = false;
		timerTick = GetComponent<AudioSource> ();
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
			if (!timerTick.isPlaying) {
				timerTick.Play ();
			}
		} else
			timerTick.Stop ();


		decimal d1 = (decimal)time;
		decimal rounded = decimal.Round (d1, 1);
		timer.text = "Time: " + rounded.ToString () + " seconds";
	}

	void OnTriggerEnter(Collider other) 
	{
		// Won game
		if (other.gameObject.CompareTag ("Finish")) {
			EndGame ();
			GameObject fin = Instantiate (finishOrb, new Vector3(other.transform.position.x,
				other.transform.position.y + 2, other.transform.position.z), other.transform.rotation);
			fin.transform.parent = other.transform;
			Destroy (gameObject);
		}

		if (other.gameObject.CompareTag ("Crystal")) {
			GameObject dis = Instantiate (discharge, new Vector3(
				other.transform.position.x,
				other.transform.position.y + 2,
				other.transform.position.z)
				, other.transform.rotation);
			
			dis.transform.parent = other.transform;
			hs.ToggleMenu ();
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
