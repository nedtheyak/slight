using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleRotation : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up, 180 * Time.deltaTime);
	}
}
