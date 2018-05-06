﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour {
	public float timeBetweenShots = 0.15f;
	public float range = 100f;
	public GameObject player;
	public Text scoreText;

	int score = 0;
	float timer;
	Ray shootRay;
	RaycastHit shootHit;
	int shootableMask;
	ParticleSystem gunParticles;
	LineRenderer gunLine;
	AudioSource gunAudio;
	Light gunLight;
	float effectsDisplayTime = 0.2f;


	void Awake () {
		shootableMask = LayerMask.GetMask ("Shootable");
		gunParticles = GetComponent<ParticleSystem> ();
		gunLine = GetComponent<LineRenderer> ();
		gunAudio = GetComponent<AudioSource> ();
		gunLight = GetComponent<Light> ();
	}


	void Update () {
		timer += Time.deltaTime;

		if (Input.GetButton("Fire1") && timer >= timeBetweenShots) {
			Shoot ();
		}

		if (timer >= timeBetweenShots * effectsDisplayTime) {
			DisableEffects ();
		}
	}

	public void DisableEffects () {
		gunLine.enabled = false;
		gunLight.enabled = false;
	}

	void Shoot () {
		timer = 0f;

		gunAudio.Play ();

		gunLight.enabled = true;

		gunParticles.Stop ();
		gunParticles.Play ();

		gunLine.enabled = true;
		gunLine.SetPosition (0, new Vector3(0,0,0));

		//mousePos += Camera.main.transform.forward * 10f;

		shootRay.origin = transform.position;
		shootRay = Camera.main.ScreenPointToRay (Input.mousePosition);

		if (Physics.Raycast (shootRay, out shootHit, range, shootableMask)) {
			AsteroidDestruct asteroidDestruct = shootHit.collider.GetComponent<AsteroidDestruct> ();
			if (asteroidDestruct != null) {
				asteroidDestruct.Destruct ();
			}
			gunLine.SetPosition (1, shootHit.point);
			score += 10;
			scoreText.text = "Score " + score;
		} else {
			gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
		}
	}
}
