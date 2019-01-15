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
    public AudioManager audioManager;
    public AudioSource[] sounds;
    public GameObject enemyDamagePrefab;

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

                // Play sound effect
                audioManager.PlayAt("Damage", transform.position);

                // Create emitter
                var enemyDamageEmitter = (GameObject)Instantiate(
                    enemyDamagePrefab,
                    this.gameObject.transform.position,
                    Quaternion.identity);
            }
            else
            {
                // Create emitter
                var enemyDamageEmitter = (GameObject)Instantiate(
                    enemyDamagePrefab,
                    this.gameObject.transform.position,
                    Quaternion.identity);

                // Kill self
                enemySpawnerHandlerScript.RemoveEnemy(this.gameObject);
            }
        }
    }

	// Initialization
	void Start () {
        damagedMat = Resources.Load<Material>("materials/Enemy_50");
        enemySpawnerHandlerScript = GameObject.Find("EnemySpawnerHandler").GetComponent<EnemySpawnerHandlerController>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        sounds = gameObject.GetComponents<AudioSource>();
        enemyDamagePrefab = Resources.Load("prefabs/EnemyDamage") as GameObject;
    }

    void Update()
    {
        if (damageCooldown > 0f)
        {
            damageCooldown -= Time.deltaTime;
        }
    }
}
