/// This script is for handling the Rail hitbox on the player


using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class RailBoxController : MonoBehaviour {

    // Variables
    public PlayerController playerControllerScript;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player(Clone)").GetComponent<PlayerController>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (playerControllerScript.isGrinding)
        {
            if (other.name.StartsWith("Rail"))
            {
                // RELEASE CLAMP
                playerControllerScript.isGrinding = false;
            }
        }
    }
}
