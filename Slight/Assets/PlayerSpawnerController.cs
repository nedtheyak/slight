using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnerController : MonoBehaviour {

    public bool spawn;
    public float timer;
    public bool newPlayer;
    public GameObject playerPrefab;



    // Use this for initialization
    void Start () {
        playerPrefab = Resources.Load("prefabs/Player") as GameObject;
        spawn = true;
    }
	
	// Update is called once per frame
	void Update () {
		if (spawn)
        {
            Instantiate(
                playerPrefab,
                this.gameObject.transform.position,
                Quaternion.Euler(new Vector3(0f, 0f, 0f)));
            spawn = false;
            newPlayer = true;
        }
        if (newPlayer)
        {
            if (timer > 0.2f)
            {
                newPlayer = false;
                timer = 0f;
            } else
            {
                timer += Time.deltaTime;
            }
        }
	}
}
