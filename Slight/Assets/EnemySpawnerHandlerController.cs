using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerHandlerController : MonoBehaviour {

    public List<GameObject> myEnemies = new List<GameObject> { };
    public bool spawnMore = true;
    public float oldCount;

    public void RemoveEnemy(GameObject givenEnemy)
    {
        myEnemies.Remove(givenEnemy);
        Destroy(givenEnemy);
    }

    // Use this for initialization
    void Start () {
		
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
            Debug.Log(myEnemies.Count.ToString());
        }
        
	}
}
