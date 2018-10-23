using UnityEngine;
using UnityEngine.UI;
using System;



public class PlayerHealth : MonoBehaviour
{


    public Vector3 MultiplyVector3(Vector3 firstVector, Vector3 secondVector)
    {
        return new Vector3(firstVector.x * secondVector.x, firstVector.y * secondVector.y, firstVector.z * secondVector.z);
    }

    // Variables
    public Rigidbody rb;
    public GameObject player;
    public Collider groundTrigger;
    public Slider powerSlider;
    public GameObject powerSliderObject;
    public GameObject HUDCanvas;
    public GameObject debugTextBox;
    public float playerHealth = 100f;
    public Slider healthSlider;
    public GameObject healthSliderObject;
    public float armorMultiplier = 2f;
    public Text debugText;
    public bool isTouchingEnemy;
    public PlayerController playerControllerScript;


    // CharacterController controller;


    public void UpdateHealth(float newValue, bool addToOld)
    {
        if (addToOld)
        {
            playerHealth += newValue;
        }
        else
        {
            playerHealth = newValue;
        }

        if (playerHealth > 100f)
        {
            playerHealth = 100f;
        }
        else if (playerHealth < 0f)
        {
            playerHealth = 0f;
            // Destroy(player);
            
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
        }

        healthSlider.value = playerHealth;
    }

    // Use this for initialization
    void Start()
    {
        Debug.Log("Game started.");
        player = GameObject.Find("Player");
        groundTrigger = player.GetComponents<Collider>()[0];
        rb = GetComponent("Rigidbody") as Rigidbody;
        HUDCanvas = GameObject.Find("HUDCanvas");
        powerSliderObject = GameObject.Find("PowerSlider");
        powerSlider = powerSliderObject.GetComponent("Slider") as Slider;
        healthSliderObject = GameObject.Find("HealthSlider");
        healthSlider = healthSliderObject.GetComponent("Slider") as Slider;
        debugTextBox = GameObject.Find("DebugTextBox");
        debugText = debugTextBox.GetComponent("Text") as Text;
        playerControllerScript = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Enemy collisions

    void OnCollisionStay(Collision collision)
    {
        if (collision.rigidbody && collision.rigidbody.name == "Enemy(Clone)")
        {
            UpdateHealth(-10f * Time.deltaTime * armorMultiplier, true);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody && collision.rigidbody.name == "Enemy(Clone)")
        {
            isTouchingEnemy = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.rigidbody && collision.rigidbody.name == "Enemy(Clone)")
        {
            isTouchingEnemy = false;
        }
    }

    /*
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.name == "Enemy(Clone)")
        {
            UpdateHealth(-10f, true);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.rigidbody.name == "Enemy(Clone)")
        {
            isGrounded = false;
        }
    }

    */

    // FixedUpdate is updated based on time, in sync with the physics engine
    void FixedUpdate()
    {

    }
}

