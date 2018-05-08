using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MLSpaceStart : MonoBehaviour {
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			this.gameObject.SetActive (false);
		}
	}
}
