using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLoseText : MonoBehaviour {
	void Update () {
		if (transform.position.z < -10) {
			Destroy (gameObject);
		}
	}
}
