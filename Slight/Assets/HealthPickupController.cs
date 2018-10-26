using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickupController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Rigidbody>() && collider.name == "Player(Clone)")
        {
            GameObject.Find("Player(Clone)").GetComponent<PlayerHealth>().UpdateHealth(25, true);
            Destroy(transform.parent.gameObject);
        }
    }
}
