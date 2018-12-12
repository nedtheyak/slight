/// This script handles the player spawner


using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerSpawnerController : MonoBehaviour {

    // Variables
    public bool spawn;
    public float timer;
    public bool newPlayer;
    public GameObject playerPrefab;
    public FollowPlayer followPlayerScript;



    // Initialization
    void Start () {
        playerPrefab = Resources.Load("prefabs/Player") as GameObject;
        spawn = true;
        followPlayerScript = GameObject.Find("Camera").GetComponent<FollowPlayer>();
    }
	

	void Update () {
		if (spawn)
        {
            // Create new player
            Instantiate(
                playerPrefab,
                this.gameObject.transform.position,
                Quaternion.Euler(new Vector3(0f, 0f, 0f)));
            spawn = false;
            newPlayer = true;

            // Ensure camera movement gets properly reset
            followPlayerScript.player = GameObject.Find("Player(Clone)");
        }
        if (newPlayer)
        {
            // Allow time for other scripts to update accordingly
            if (timer > 0.21f)
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
