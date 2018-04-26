using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public GameObject asteroid;
	public GameObject loseText;
	public Vector3 spawnValues;
	public float timeBetweenSpawns;
	public bool spawning = true;


	void Start () {
		StartCoroutine(SpawnWaves ());
	}

	IEnumerator SpawnWaves () {
		while (spawning) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), Random.Range (-5, 8), spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (asteroid, spawnPosition, spawnRotation);
			yield return new WaitForSeconds (timeBetweenSpawns);

			// Stops the asteroid spawnings
			if (!GameObject.Find("Player")) {
				spawning = false;
				Instantiate (loseText, new Vector3 (0, 0, 500), new Quaternion());
			}
		}
	}
}
