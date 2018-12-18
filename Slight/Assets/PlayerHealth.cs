/// This script handles the player's health and UI health bar


using UnityEngine;
using UnityEngine.UI;
using System;



public class PlayerHealth : MonoBehaviour
{

    // Custom vector3 manipulation functions
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
    public Text debugText;
    public float playerHealth = 100f;
    public Slider healthSlider;
    public GameObject healthSliderObject;
    public float armorMultiplier = 2f;
    public bool isTouchingEnemy;
    public PlayerController playerControllerScript;
    public PlayerSpawnerController playerSpawnerControllerScript;
    public AudioManager audioManager;


    // CharacterController controller;


    public void UpdateHealth(float newValue, bool addToOld)
    {
        // Add or set the health
        if (addToOld)
        {
            playerHealth += newValue;
        }
        else
        {
            playerHealth = newValue;
        }

        // Cap health at 100f, kill player at 0f
        if (playerHealth > 100f)
        {
            playerHealth = 100f;
        }
        else if (playerHealth < 0f)
        {
            playerHealth = 0f;
            if (playerControllerScript.isSlashing)
            {
                Destroy(GameObject.Find("SlashImage(Clone)"));
            }
            audioManager.Play("PlayerDeath");
            playerSpawnerControllerScript.spawn = true;
            Destroy(GameObject.Find("Player(Clone)"));
        }

        // Update UI slider
        healthSlider.value = playerHealth;
    }

    // Initialization
    void Start()
    {
        Debug.Log("Player Spawned.");
        player = GameObject.Find("Player(Clone)");
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
        playerSpawnerControllerScript = GameObject.Find("PlayerSpawner").GetComponent<PlayerSpawnerController>();
        UpdateHealth(100f, false);
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }



    // Reduce health on enemy collisions

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
}

