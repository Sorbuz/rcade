using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsteroidDestruct : MonoBehaviour {
	public GameObject asteroidExplosion;
	public GameObject playerExplosion;

	AudioSource explode;
	GameObject player;
	PlayerHealth ph;

	void Awake ()
	{
		explode = this.GetComponent<AudioSource> ();
	}

	void Start()
	{
		player = GameObject.Find ("Player");
		ph = player.GetComponent<PlayerHealth> ();
	}


	// Asteroid hits player
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			Destruct ();

			ph.DecreaseHealth (33);
			if (ph.GetHealth() < 10) {
				Destroy (other.gameObject);
				Instantiate (playerExplosion, transform.position, transform.rotation);
			}
		}
	}
		
	// Laser hits asteroid
	public void Destruct () {
		Debug.Log (explode.clip);

		Destroy (gameObject);
		Instantiate (asteroidExplosion, transform.position, transform.rotation);
	}

	void Update () {
		if (gameObject.transform.position.z < -10) {
			Destroy (gameObject);
		}
	}
}
