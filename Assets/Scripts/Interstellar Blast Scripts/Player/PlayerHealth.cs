using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public Slider healthbar;

	AudioSource explosion;
	int playerHealth;

	void Start()
	{
		playerHealth = 100;
		explosion = GetComponent<AudioSource> ();
	}

	public void DecreaseHealth(int amount)
	{
		explosion.Play ();
		playerHealth = playerHealth - amount;
		healthbar.value = playerHealth;
	}

	public int GetHealth()
	{
		return playerHealth;
	}
}
