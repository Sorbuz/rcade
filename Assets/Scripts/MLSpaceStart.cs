using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MLSpaceStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			this.gameObject.SetActive (false);
		}
	}
}
