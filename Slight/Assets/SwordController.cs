using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour {


    public bool attack;

	// Use this for initialization
	void Start () {
        attack = false;
	}

    private void OnTriggerEnter(Collider other)
    {
        
    }

    // Update is called once per frame
    void FixedUpdate () {
		if (attack)
        {
            Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.identity);
            foreach (Collider collider in hitColliders)
            {
                Destroy(collider.gameObject);
            }
            attack = false;
        }
	}
}
