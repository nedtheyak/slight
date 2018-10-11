using UnityEngine;
using UnityEngine.UI;
using System;

public class EnemyMovement : MonoBehaviour {

    // Functions
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
    PlayerHealth playerHealthScript;

    // Use this for initialization
    void Start () {
        isGrounded = false;
        player = GameObject.Find("Player");
        playerHealthScript = player.GetComponent<PlayerHealth>();
        rb = GetComponent("Rigidbody") as Rigidbody;
        debugTextBox = GameObject.Find("DebugTextBox");
        debugText = debugTextBox.GetComponent("Text") as Text;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "Player")
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name != "Player")
        {
            isGrounded = false;
        }
    }

    // Update is called once per frame
    void Update () {
        transform.LookAt(player.transform);
        if (isGrounded && !playerHealthScript.isTouchingEnemy)
        {
            debugText.text = AddVector3(MultiplyVector3(transform.forward, movespeed), new Vector3(0f, rb.velocity.y, 0f)).ToString();
            rb.velocity = AddVector3(MultiplyVector3(transform.forward, movespeed), new Vector3(0f, rb.velocity.y, 0f));
        }
	}
}
