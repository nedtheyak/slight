/// This script handles the player's sword interactions


using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SwordController : MonoBehaviour {

    // Variables
    public float attack;
    public PlayerController playerControllerScript;
    public EnemySpawnerHandlerController enemySpawnerHandlerScript;
    public AudioManager audioManager;


    // Initialization
    void Start () {
        attack = 0f;
        playerControllerScript = GameObject.Find("Player(Clone)").GetComponent<PlayerController>();
        enemySpawnerHandlerScript = GameObject.Find("EnemySpawnerHandler").GetComponent<EnemySpawnerHandlerController>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    
    void FixedUpdate () {
		if (attack > 0f)
        {
            // Get all colliders in sword hitbox
            Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.identity);
            foreach (Collider collider in hitColliders)
            {
                // Kill if it is an enemy
                if (collider.name == "Enemy(Clone)")
                {
                    enemySpawnerHandlerScript.RemoveEnemy(collider.gameObject);
                }
            }
            if ((attack - Time.deltaTime) < 0f)
            {
                // Remove slash animation
                Destroy(GameObject.Find("SlashImage(Clone)"));
                playerControllerScript.isSlashing = false;
                audioManager.Stop("Slash");
            }
            attack -= Time.deltaTime;
        }
	}
}
