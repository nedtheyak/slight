/// This script handles the health pickup interactions


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickupController : MonoBehaviour {

    // Contact with player adds health to player and destroys self
    void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Rigidbody>() && collider.name == "Player(Clone)")
        {
            // Add health
            GameObject.Find("Player(Clone)").GetComponent<PlayerHealth>().UpdateHealth(25, true);

            // Destroy self
            Destroy(transform.parent.gameObject);
        }
    }
}
