using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour {

    public float maxScale = 5f;
    public float timer = 0.00000000000000000001f;
    public float timerMax = 1f;

	// Use this for initialization
	void Start () {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Enemy(Clone)")
        {
            Destroy(collider.gameObject);
        }
    }

    // FixedUpdate is updated based on time, in sync with the physics engine
    void FixedUpdate () {
        transform.localScale = new Vector3(timer * maxScale, timer * maxScale, timer * maxScale);

        if (timerMax == 1f)
        {
            timer += Time.deltaTime;
            if (timer >= timerMax)
            {
                timerMax = 0f;
            }
        } else
        {
            timer -= Time.deltaTime * 1.5f;
        }

        if (timer <= 0f)
        {
            Destroy(this.gameObject);
        }
	}
}
