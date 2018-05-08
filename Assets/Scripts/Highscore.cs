using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour {
	public Text text1;
	public Text text2;
	public Text text3;

	float time;
	float tempTime;
	float t1;
	float t2;
	float t3;
	int score;

	// Use this for initialization
	void Start () {
		t1 = PlayerPrefs.GetFloat ("MB1");
		t2 = PlayerPrefs.GetFloat ("MB2");
		t3 = PlayerPrefs.GetFloat ("MB3");
	}

	void SetHighscore () 
	{
		float[] times = new float[] { t1, t2, t3 };

		for (int i = 0; i < times.Length; i++) {
			if (time < times[i] || times[i] == 0) {
				tempTime = times [i];
				for (int j = i; j < times.Length; j++) {
					if (tempTime < times [j] || times [j] == 0) {
						string tempKey = "MB" + (j + 1);
						PlayerPrefs.SetFloat (tempKey, tempTime);
					}
				}
				string key = "MB" + (i + 1);
				PlayerPrefs.SetFloat (key, time);
				break;
			}
		}
		SetText ();
		foreach (float i in times)
			Debug.Log (i);
	}

	public void SetTime(float t)
	{
		time = t;
		SetHighscore ();
	}

	void SetText()
	{
		text1.text = "1. " + Math.Round(PlayerPrefs.GetFloat ("MB1"), 2) + " seconds";
		text2.text = "2. " + Math.Round(PlayerPrefs.GetFloat ("MB2"), 2) + " seconds";
		text3.text = "3. " + Math.Round(PlayerPrefs.GetFloat ("MB3"), 2) + " seconds";
	}

	public void ResetHighscore()
	{
		PlayerPrefs.DeleteKey ("MB1");
		PlayerPrefs.DeleteKey ("MB2");
		PlayerPrefs.DeleteKey ("MB3");
		SetText ();
	}
}
