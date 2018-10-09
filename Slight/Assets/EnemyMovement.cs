using UnityEngine;
using UnityEngine.UI;
using System;

public class EnemyMovement : MonoBehaviour {

    // Functions
    public Vector3 MultiplyVector3(Vector3 firstVector, Vector3 secondVector)
    {
        return new Vector3(firstVector.x * secondVector.x, firstVector.y * secondVector.y, firstVector.z * secondVector.z);
    }

    // Variables
    public Rigidbody rb;
    public Vector3 velMoveHorizontal;
    public Vector3 velMoveVertical;
    public float moveHorizontal;
    public float moveVertical;
    public Vector3 movementRotation;
    public Vector3 movespeed = new Vector3(1f, 0f, 1f);
    public bool isGrounded;
    public GameObject player;
    public GameObject debugTextBox;
    public Text debugText;

    // Use this for initialization
    void Start () {
        isGrounded = false;
        player = GameObject.Find("Player");
        rb = GetComponent("Rigidbody") as Rigidbody;
        debugTextBox = GameObject.Find("DebugTextBox");
        debugText = debugTextBox.GetComponent("Text") as Text;
    }

    private void OnTriggerEnter(Collider other)
    {
        isGrounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isGrounded = false;
    }

    // Update is called once per frame
    void Update () {
        transform.LookAt(player.transform);
        //while (isGrounded)
        //{
        debugText.text = MultiplyVector3(transform.forward, movespeed).ToString();
            rb.velocity = MultiplyVector3(transform.forward, movespeed);
        //}
	}
}
