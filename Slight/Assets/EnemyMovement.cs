/// This script handles enemy movement and physics control


using UnityEngine;
using UnityEngine.UI;
using System;




public class EnemyMovement : MonoBehaviour {

    // Custom vector3 manipulation functions
    public Vector3 MultiplyVector3(Vector3 firstVector, Vector3 secondVector)
    {
        return new Vector3(firstVector.x * secondVector.x, firstVector.y * secondVector.y, firstVector.z * secondVector.z);
    }
    public Vector3 AddVector3(Vector3 firstVector, Vector3 secondVector)
    {
        return new Vector3(firstVector.x + secondVector.x, firstVector.y + secondVector.y, firstVector.z + secondVector.z);
    }

    // Variables
    public Rigidbody rb;
    public Vector3 velMoveHorizontal;
    public Vector3 velMoveVertical;
    public float moveHorizontal;
    public float moveVertical;
    public Vector3 movementRotation;
    public Vector3 movespeed = new Vector3(5f, 0f, 5f);
    public bool isGrounded;
    public GameObject player;
    public GameObject debugTextBox;
    public Text debugText;
    //PlayerHealth playerHealthScript;
    public PlayerSpawnerController playerSpawnerControllerScript;


    // Initialization
    void Start () {
        isGrounded = false;
        player = GameObject.Find("Player(Clone)");
        //playerHealthScript = player.GetComponent<PlayerHealth>();
        rb = GetComponent("Rigidbody") as Rigidbody;
        debugTextBox = GameObject.Find("DebugTextBox");
        debugText = debugTextBox.GetComponent("Text") as Text;
        playerSpawnerControllerScript = GameObject.Find("PlayerSpawner").GetComponent<PlayerSpawnerController>();
    }


    // Handles grounding for only moving when on the ground
    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "Player(Clone)" && !other.isTrigger)
        {
            isGrounded = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name != "Player(Clone)" && !other.isTrigger)
        {
            isGrounded = false;
        }
    }


    // Get player, look at player, move towards player
    void Update () {
        // Check for new players
        if (playerSpawnerControllerScript.newPlayer)
        {
            // Get new player object
            player = GameObject.Find("Player(Clone)");
            //playerHealthScript = player.GetComponent<PlayerHealth>();
        }

        // Point towards player
        transform.LookAt(player.transform);

        // Move enemy
        if (isGrounded/* && !playerHealthScript.isTouchingEnemy*/)
        {
            rb.velocity = AddVector3(MultiplyVector3(transform.forward, movespeed), new Vector3(0f, rb.velocity.y, 0f));
        }
	}
}
