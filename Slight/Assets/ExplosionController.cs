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

    // Explosion launch power
    public float explosionPower = 50f;


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Enemy(Clone)")
        {
            // Damage enemy
            collider.gameObject.GetComponent<EnemyHealth>().DamageEnemy();

            // Launch enemy
            collider.gameObject.transform.LookAt(this.gameObject.transform);
            collider.gameObject.GetComponent<Rigidbody>().velocity = collider.gameObject.transform.forward * -explosionPower;

            // Start reducing explosion size
            timerMax = 0f;
        }
    }

    // Set scale and update timer, destroy explosion when timer hits zero
    void FixedUpdate () {
        // Set the scale to a percentage of the max
        transform.localScale = new Vector3(timer * maxScale, timer * maxScale, timer * maxScale);

        // Update timer
        if (timerMax == 1f)
        {
            timer += Time.deltaTime * 10f;
            if (timer >= timerMax)
            {
                timerMax = 0f;
            }
        } else
        {
            timer -= Time.deltaTime * 8f;
        }

        // Destroy explosion when timer hits zero
        if (timer <= 0f)
        {
            Destroy(this.gameObject);
        }
	}
}
