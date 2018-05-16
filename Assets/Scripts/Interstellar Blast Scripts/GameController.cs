using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameController : MonoBehaviour {
	public GameObject asteroid;
	public GameObject loseText;
	public Vector3 spawnValues;
	public float timeBetweenSpawns;
	public bool spawning = true;
	public GameObject menu;
	public TextMeshProUGUI score;
	public HighscoreIB hs;


	void Start () {
		menu.SetActive (false);
		StartCoroutine(SpawnWaves ());
	}

	IEnumerator SpawnWaves () {
		while (spawning) {
				Vector3 spawnPosition = new Vector3 (UnityEngine.Random.Range (-spawnValues.x, spawnValues.x), UnityEngine.Random.Range (-5, 8), spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (asteroid, spawnPosition, spawnRotation);
			yield return new WaitForSeconds (timeBetweenSpawns);

			// Stops the asteroid spawnings
			if (!GameObject.Find("Player")) {
				spawning = false;
				Instantiate (loseText, new Vector3 (0, 0, 500), new Quaternion());

				int endScore = Int32.Parse (score.text.Substring(6, score.text.Length - 6));
				hs.SetScore (endScore);
			}
		}
	}
}
