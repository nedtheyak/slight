using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour {


    public float attack;

	// Use this for initialization
	void Start () {
        attack = 0f;
	}

    private void OnTriggerEnter(Collider other)
    {
        
    }

    // Update is called once per frame
    void FixedUpdate () {
		if (attack > 0f)
        {
            Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.identity);
            foreach (Collider collider in hitColliders)
            {
                if (collider.name == "Enemy(Clone)")
                {
                    Destroy(collider.gameObject);
                }
            }
            attack -= Time.deltaTime;
            if (attack < 0f)
            {
                // Stop animation, reset frame
            }
        }
	}
}
