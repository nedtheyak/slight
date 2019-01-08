/// This script handles the handler for all enemy spawners


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerHandlerController : MonoBehaviour {

    // Used for keeping track of all enemies in the world
    public List<GameObject> myEnemies = new List<GameObject> { };

    // Used for tracking when to spawn
    // Whether or not to continue spawning
    public bool spawnMore = true;
    
    // Used to *force* stop of spawning
    public bool stopSpawning = false;
    
    // Used to track the previous enemy count (for comparison against new)
    public float oldCount;

    // This is used for adding points on enemy removal
    public PointsHandlerController pointsHandlerScript;


    // This is for removing enemies
    public void RemoveEnemy(GameObject givenEnemy)
    {
        // Update enemy count
        oldCount = myEnemies.Count;
        // Remove the enemy from the list
        myEnemies.Remove(givenEnemy);
        // Remove the enemy from the scene
        Destroy(givenEnemy);
        // Add points to the counter if the enemy count has diminished
        pointsHandlerScript.AddPoints((int)(oldCount - myEnemies.Count));
    }

    // This is for stomping enemies
    public void RemoveEnemyStomp(GameObject givenEnemy, Rigidbody rb)
    {
        // Update enemy count
        oldCount = myEnemies.Count;
        // Remove the enemy from the list
        myEnemies.Remove(givenEnemy);
        // Remove the enemy from the scene
        Destroy(givenEnemy);
        // Add points to the counter if the enemy count has diminished
        pointsHandlerScript.AddPoints((int)(oldCount - myEnemies.Count));

        // Add the stomp jump velocity
        rb.velocity = new Vector3(rb.velocity.x, 12.0f, rb.velocity.z);
    }

    // Initialization
    void Start () {
        // Get the pointsHandler's script
        pointsHandlerScript = GameObject.Find("PointsHandler").GetComponent<PointsHandlerController>();
    }
	
    // Every frame, update whether or not to spawn more enemies
	void Update () {
        if (myEnemies.Count != oldCount && !stopSpawning)
        {
            oldCount = myEnemies.Count;
            if (oldCount >= 50f)
            {
                spawnMore = false;
            }
            else
            {
                spawnMore = true;
            }
        }
        
	}
}
