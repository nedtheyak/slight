/// This script handles constant rotation of HealthPickup capsules


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleRotation : MonoBehaviour {

    // Rotate capsule along the global y axis 180 degrees every second
    void Update () {
        transform.Rotate(Vector3.up, 180 * Time.deltaTime);
	}
}
