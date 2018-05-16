using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using System;

public class HighscoreIB : MonoBehaviour {
	public TextMeshProUGUI text1;
	public TextMeshProUGUI text2;
	public TextMeshProUGUI text3;

	int s1;
	int s2;
	int s3;
	int score;

	void Start () {
		s1 = PlayerPrefs.GetInt ("IB1");
		s2 = PlayerPrefs.GetInt ("IB2");
		s3 = PlayerPrefs.GetInt ("IB3");
	}

	void SetHighscore ()
	{
		int[] scores = new int[] { s1, s2, s3 };

		for (int i = 0; i < scores.Length; i++) {
			if (score > scores [i]) {
				string key = "IB" + (i + 1);
				PlayerPrefs.SetInt (key, score);

				int tempScore = scores [i];
				for (int j = i; j < scores.Length; j++) {
					if (tempScore > scores [j]) {
						string tempKey = "IB" + (j + 1);
						scores [j] = tempScore;
						PlayerPrefs.SetInt (tempKey, tempScore);
						break;
					}
				}
				break;
			}
		}
		SetText ();
	}

	void SetText ()
	{
		text1.text = "1. " + PlayerPrefs.GetInt ("IB1");
		text2.text = "2. " + PlayerPrefs.GetInt ("IB2");
		text3.text = "3. " + PlayerPrefs.GetInt ("IB3");
	}

	public void SetScore (int s)
	{
		gameObject.SetActive (true);
		score = s;
		SetHighscore ();
	}

	public void ResetHighscore()
	{
		PlayerPrefs.DeleteKey ("IB1");
		PlayerPrefs.DeleteKey ("IB2");
		PlayerPrefs.DeleteKey ("IB3");
		SetText ();
	}
}
