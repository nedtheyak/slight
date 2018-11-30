using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerHandlerController : MonoBehaviour {

    public List<GameObject> myEnemies = new List<GameObject> { };
    public bool spawnMore = true;
    public float oldCount;
    public PointsHandlerController pointsHandlerScript;

    public void RemoveEnemy(GameObject givenEnemy)
    {
        oldCount = myEnemies.Count;
        myEnemies.Remove(givenEnemy);
        Destroy(givenEnemy);
        pointsHandlerScript.AddPoints((int)(oldCount - myEnemies.Count));
    }

    // Use this for initialization
    void Start () {
        pointsHandlerScript = GameObject.Find("PointsHandler").GetComponent<PointsHandlerController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (myEnemies.Count != oldCount)
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
