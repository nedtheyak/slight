using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class EnemySpawnerController : MonoBehaviour {

    private List<GameObject> myEnemies = new List<GameObject> { };
    public float timer;
    public GameObject enemyPrefab;

	void Start () {
        timer = Time.deltaTime;
        enemyPrefab = Resources.Load("prefabs/Enemy") as GameObject;
        myEnemies.Add((GameObject)Instantiate(
            enemyPrefab,
            this.gameObject.transform.position,
            Quaternion.Euler(new Vector3(0f, 0f, 0f))));
    }
	
	void FixedUpdate () {
        timer += Time.deltaTime;
        if (timer > 5f)
        {
            
            myEnemies.Add((GameObject)Instantiate(
                enemyPrefab,
                this.gameObject.transform.position,
                Quaternion.Euler(new Vector3(0f, 0f, 0f))));
            timer = 0f;
        }
    }
}
