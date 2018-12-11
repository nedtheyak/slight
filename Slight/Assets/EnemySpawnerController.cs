/// This script handles enemy spawners


using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;




public class EnemySpawnerController : MonoBehaviour {
    
    public float timer;
    public GameObject enemyPrefab;

    // EnemySpawnerHandler script for adding enemies to the comprehensive list of enemies
    public EnemySpawnerHandlerController handlerScript;

    // Create randomizer
    private System.Random rnd = new System.Random();



	void Start () {
        // Add an initial timer offset so spawners don't all spawn simultaneously
        timer = -rnd.Next(0, 5);

        // Load enemy prefab
        enemyPrefab = Resources.Load("prefabs/Enemy") as GameObject;

        // Get EnemySpawnerHandler script
        handlerScript = this.gameObject.GetComponentInParent<EnemySpawnerHandlerController>();
    }
	
	void FixedUpdate () {
        if (handlerScript.spawnMore)
        {
            timer += Time.deltaTime;
            if (timer > 5f)
            {
                // Spawn enemy and add it to the comprehensive list of enemies
                handlerScript.myEnemies.Add((GameObject)Instantiate(
                    enemyPrefab,
                    this.gameObject.transform.position,
                    Quaternion.Euler(new Vector3(0f, 0f, 0f))));

                // Reset the timer
                timer = 0f;
            }
        }
    }
}
