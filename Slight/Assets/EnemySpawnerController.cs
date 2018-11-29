using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class EnemySpawnerController : MonoBehaviour {
    
    public float timer;
    public GameObject enemyPrefab;
    public EnemySpawnerHandlerController handlerScript;
    private System.Random rnd;

	void Start () {
        timer = -rnd.Next(0, 5);
        enemyPrefab = Resources.Load("prefabs/Enemy") as GameObject;
        handlerScript = GameObject.Find("EnemySpawnerHandler").GetComponent<EnemySpawnerHandlerController>();
    }
	
	void FixedUpdate () {
        if (handlerScript.spawnMore)
        {
            timer += Time.deltaTime;
            if (timer > 5f)
            {
                handlerScript.myEnemies.Add((GameObject)Instantiate(
                    enemyPrefab,
                    this.gameObject.transform.position,
                    Quaternion.Euler(new Vector3(0f, 0f, 0f))));
                timer = 0f;
            }
        }
    }
}
