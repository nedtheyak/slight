/// This script handles the movement of the camera, keeping it inside of the player (with an offset)


using UnityEngine;

public class FollowPlayer : MonoBehaviour {


    public GameObject player;
    public Vector3 offset;

	// Initialization
	void Start () {
        // Get player
        player = GameObject.Find("Player(Clone)");

        // Set offset
        offset = new Vector3(0, 1, 0);
    }
	
	// Move camera into player (with offset) every frame
	void Update () {
        // Set camera position
        transform.position = player.transform.position + offset;
	}
}