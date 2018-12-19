/// This script handles enemy health and damage reactions


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    // Variables
    public float enemyHealth = 2f;
    public float damageCooldown = 0f;
    public EnemySpawnerHandlerController enemySpawnerHandlerScript;
    public Material damagedMat;


    // Function called when damaged
    public void DamageEnemy()
    {
        if (damageCooldown <= 0f)
        {
            if (enemyHealth == 2f)
            {
                // Apply new visual material
                this.gameObject.GetComponent<Renderer>().material = damagedMat;

                // Reduce health
                enemyHealth = 1f;

                // Give invincibility time
                damageCooldown = 0.05f;
            }
            else
            {
                // Kill self
                enemySpawnerHandlerScript.RemoveEnemy(this.gameObject);
            }
        }
    }

	// Initialization
	void Start () {
        damagedMat = Resources.Load<Material>("materials/Enemy_50");
        enemySpawnerHandlerScript = GameObject.Find("EnemySpawnerHandler").GetComponent<EnemySpawnerHandlerController>();
    }

    void Update()
    {
        if (damageCooldown > 0f)
        {
            damageCooldown -= Time.deltaTime;
        }
    }
}
