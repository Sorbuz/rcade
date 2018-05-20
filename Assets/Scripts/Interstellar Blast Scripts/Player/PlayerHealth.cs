using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public Slider healthbar;
	int playerHealth;

	void Start()
	{
		playerHealth = 100;
	}

	public void DecreaseHealth(int amount)
	{
		playerHealth = playerHealth - amount;
		Debug.Log (playerHealth);
		healthbar.value = playerHealth;
	}

	public int GetHealth()
	{
		return playerHealth;
	}
}
