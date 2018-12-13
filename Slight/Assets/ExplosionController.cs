/// This script handles explosions


using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class ExplosionController : MonoBehaviour {

    // Variables
    // Maximum explosion radius
    public float maxScale = 5f;

    // Initialize timer
    public float timer = 0.00000000000000000001f;
    
    // Maximum time
    public float timerMax = 1f;


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Enemy(Clone)")
        {
            // Damage enemy
            collider.gameObject.GetComponent<EnemyHealth>().DamageEnemy();
        }
    }

    // Set scale and update timer, destroy explosion when timer hits zero
    void FixedUpdate () {
        // Set the scale to a percentage of the max
        transform.localScale = new Vector3(timer * maxScale, timer * maxScale, timer * maxScale);

        // Update timer
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

        // Destroy explosion when timer hits zero
        if (timer <= 0f)
        {
            Destroy(this.gameObject);
        }
	}
}
