using UnityEngine;
using UnityEngine.UI;
using System;



public class PlayerController : MonoBehaviour {


    public Vector3 MultiplyVector3(Vector3 firstVector, Vector3 secondVector) {
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
    public float oldYVel;
    public float moveHorizontal;
    public float moveVertical;
    public Vector3 movementRotation;
    public Vector3 movespeed = new Vector3(15f, 0f, 15f);
    public float movespeedLimit = 60f;
    public Vector3 midairModifier = new Vector3(2f, 0f, 2f);
    public Vector3 groundedModifier = new Vector3(1f, 0f, 1f);
    public float playerDynamicFriction = 0.6f;
    public float playerStaticFriction = 0.2f;
    public float jetpackPower = 125f;
    public float jetpackMeterLimit = 50f;
    public float jetpackMeter;
    public float jetpackRecoveryRate = 0.15f;
    public bool isGrounded;
    public bool isSkiing;
    public GameObject player;
    public PhysicMaterial playerMat;
    public Collider groundTrigger;
    public Slider powerSlider;
    public GameObject powerSliderObject;
    public GameObject HUDCanvas;
    public GameObject debugTextBox;
    public float armorMultiplier = 2f;
    public Text debugText;
    public Boolean isDead = false;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 50f;
    public float bulletTime = 0.8f;
    public Vector3 bulletRotation;


    // CharacterController controller;

    // Use this for initialization
    void Start () {
        Debug.Log("Game started.");
        isGrounded = false;
        isSkiing = false;
        jetpackMeter = jetpackMeterLimit;
        player = GameObject.Find("Player");
        playerMat = player.GetComponent<Collider>().material;
        player.GetComponent<Collider>().material.dynamicFriction = playerDynamicFriction;
        player.GetComponent<Collider>().material.staticFriction = playerStaticFriction;
        groundTrigger = player.GetComponents<Collider>()[0];
        rb = GetComponent("Rigidbody") as Rigidbody;
        HUDCanvas = GameObject.Find("HUDCanvas");
        powerSliderObject = GameObject.Find("PowerSlider");
        powerSlider = powerSliderObject.GetComponent("Slider") as Slider;
        debugTextBox = GameObject.Find("DebugTextBox");
        debugText = debugTextBox.GetComponent("Text") as Text;
        bulletSpawn = GameObject.Find("BulletSpawn").GetComponent<Transform>();
        bulletPrefab = Resources.Load("prefabs/Bullet") as GameObject;
    }
	
	// Update is called once per frame
	void Update () {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, Camera.main.transform.rotation.eulerAngles.y, transform.eulerAngles.z);

        if (Input.GetButtonDown("Fire1"))
        {
            FireMain();
        }

        if (Input.GetButtonDown("Modifier"))
        {
            if (isSkiing)
            {
                player.GetComponent<Collider>().material.dynamicFriction = playerDynamicFriction;
                player.GetComponent<Collider>().material.staticFriction = playerStaticFriction;
                player.GetComponent<Collider>().material.frictionCombine = PhysicMaterialCombine.Average;
                isSkiing = false;
            } else
            {
                player.GetComponent<Collider>().material.dynamicFriction = 0f;
                player.GetComponent<Collider>().material.staticFriction = 0f;
                player.GetComponent<Collider>().material.frictionCombine = PhysicMaterialCombine.Minimum;
                isSkiing = true;
            }
        }
    }

    void FireMain()
    {
        // Create the Bullet from the Bullet Prefab
        bulletRotation = new Vector3(Camera.main.transform.rotation.eulerAngles.x, bulletSpawn.rotation.eulerAngles.y, bulletSpawn.rotation.eulerAngles.z);
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            Quaternion.Euler(bulletRotation));

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = AddVector3(bullet.transform.forward * bulletSpeed, rb.velocity);

        // Destroy the bullet after 2 seconds
        Destroy(bullet, bulletTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger)
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.isTrigger)
        {
            isGrounded = false;
        }
    }

    // FixedUpdate is updated based on time, in sync with the physics engine
    void FixedUpdate() {
        // MOVING THE PLAYER
        moveHorizontal = - Input.GetAxis("Horizontal");
        moveVertical = - Input.GetAxis("Vertical");

        if (isGrounded && !isSkiing)
        {
            // rb.AddForce(MultiplyVector3(Camera.main.transform.TransformDirection(new Vector3(moveHorizontal, 0f, moveVertical).normalized).normalized, movespeed));
            // rb.AddRelativeForce(MultiplyVector3(MultiplyVector3(new Vector3(moveHorizontal, 0f, moveVertical).normalized, movespeed), groundedModifier));

            // Ground movement (using trig functions with weird mods to make it relative to the player's rotation)
            velMoveHorizontal = -MultiplyVector3(MultiplyVector3(MultiplyVector3(new Vector3(moveHorizontal, 0f, moveHorizontal), movespeed), groundedModifier), new Vector3((float)Math.Cos(player.transform.rotation.eulerAngles.y * (Math.PI / 180)), 0f, -(float)Math.Sin(player.transform.rotation.eulerAngles.y * (Math.PI / 180))));
            velMoveVertical = -MultiplyVector3(MultiplyVector3(MultiplyVector3(new Vector3(moveVertical, 0f, moveVertical), movespeed), groundedModifier), new Vector3((float)Math.Sin(player.transform.rotation.eulerAngles.y * (Math.PI / 180)), 0f, (float)Math.Cos(player.transform.rotation.eulerAngles.y * (Math.PI / 180))));
            oldYVel = rb.velocity.y;
            if (oldYVel > 0)
            {
                oldYVel = 0;
            }
            rb.velocity = new Vector3(velMoveHorizontal.x + velMoveVertical.x, oldYVel, velMoveHorizontal.z + velMoveVertical.z);
            // debugText.text = (new Vector3((float)Math.Cos(player.transform.rotation.eulerAngles.y * (Math.PI / 180)), 0f, (float)Math.Sin(player.transform.rotation.eulerAngles.y * (Math.PI / 180)))).ToString();
        }
        else if (true)
        {
            // rb.AddForce(MultiplyVector3(MultiplyVector3(Camera.main.transform.TransformDirection(new Vector3(moveHorizontal, 0f, moveVertical).normalized).normalized, movespeed), midairModifier));
            moveHorizontal = -moveHorizontal;
            moveVertical = -moveVertical;

            // Limit velocity
            if (Math.Abs((moveHorizontal * movespeed.x * midairModifier.x) + rb.GetRelativePointVelocity(new Vector3(0f, 0f, 0f)).x) >= movespeedLimit && Math.Abs((moveHorizontal * movespeed.x * midairModifier.x) + rb.GetRelativePointVelocity(new Vector3(1f, 0f, 0f)).x) > rb.GetRelativePointVelocity(new Vector3(1f, 0f, 0f)).x)
            {
                moveHorizontal = 0f;
            }
            
            if (Math.Abs((moveVertical * movespeed.z * midairModifier.z) + rb.GetRelativePointVelocity(new Vector3(0f, 0f, 0f)).z) >= movespeedLimit && Math.Abs((moveVertical * movespeed.z * midairModifier.z) + rb.GetRelativePointVelocity(new Vector3(0f, 0f, 1f)).z) > rb.GetRelativePointVelocity(new Vector3(0f, 0f, 1f)).z)
            {
                moveVertical = 0f;
            }
            
            // Add the force
            rb.AddRelativeForce(MultiplyVector3(MultiplyVector3(new Vector3(moveHorizontal, 0f, moveVertical).normalized, movespeed), midairModifier));
        }
        

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Joystick1Button1))
        {
            if (isGrounded)
            {
                rb.velocity = new Vector3(rb.velocity.x, 12.0f, rb.velocity.z);
            }
            else if (jetpackMeter > 0)
            {
                rb.AddForce(new Vector3(0f, jetpackPower, 0f));
                jetpackMeter -= 1f;
                powerSlider.value = 100f * (jetpackMeter / jetpackMeterLimit);
                if (jetpackMeter < 0)
                {
                    jetpackMeter = 0;
                }
            }
        } else if (jetpackMeter < jetpackMeterLimit)
        {
            if (isGrounded)
            {
                jetpackMeter += jetpackRecoveryRate * 3f;
            } else
            {
                jetpackMeter += jetpackRecoveryRate;
            }
            powerSlider.value = 100f * (jetpackMeter / jetpackMeterLimit);
        }
    }
}

