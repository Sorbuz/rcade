using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDestruct : MonoBehaviour {
	public GameObject asteroidExplosion;
	public GameObject playerExplosion;

	// Asteroid hits player
	void OnTriggerEnter(Collider other) {
		if (other.tag != "Indestructible") {
			Destroy (gameObject);
			Destroy (other.gameObject);
			Instantiate (playerExplosion, transform.position, transform.rotation);
		}
	}
		
	// Laser hits asteroid
	public void Destruct () {
		Destroy (gameObject);
		Instantiate (asteroidExplosion, transform.position, transform.rotation);
	}

	void Update () {
		if (gameObject.transform.position.z < -10) {
			Destroy (gameObject);
		}
	}
}
