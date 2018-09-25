using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;

    public Vector3 MultiplyVector3(Vector3 firstVector, Vector3 secondVector) {
        return new Vector3(firstVector.x * secondVector.x, firstVector.y * secondVector.y, firstVector.z * secondVector.z);
    }

    // !!!!!!!!!!!!!!!! MOVE THESE VARIABLES ELSEWHERE - CLASSES (LEARN W/ JASON) !!!!!!!!!!!!!!!!
    public float xForce = 0f;
    public float yForce = 0f;
    public float zForce = 0f;
    public float moveHorizontal;
    public float moveVertical;
    public Vector3 movementRotation;
    public Vector3 movespeed = new Vector3(100f, 0f, 100f);
    public Vector3 midairModifier = new Vector3(0.25f, 0f, 0.25f);
    public Vector3 groundedModifier = new Vector3(1f, 0f, 1f);
    public float jetpackPower = 25f;
    public float jetpackMeterLimit = 50f;
    public float jetpackMeter;
    public float jetpackRecoveryRate = 0.15f;
    public bool isGrounded;
    public bool isSkiing;
    public GameObject player;
    public Slider healthSlider;

    // CharacterController controller;


    // Use this for initialization
    void Start () {
        Debug.Log("Game started.");
        isGrounded = false;
        isSkiing = false;
        jetpackMeter = jetpackMeterLimit;
    }
	
	// Update is called once per frame
	void Update () {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, Camera.main.transform.rotation.eulerAngles.y, transform.eulerAngles.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.name == "raceTrackLakeLevel")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.rigidbody.name == "raceTrackLakeLevel")
        {
            isGrounded = false;
        }
    }

    // FixedUpdate is updated based on time, in sync with the physics engine
    void FixedUpdate() {
        // MOVING THE PLAYER
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        if (isGrounded && !isSkiing)
        {
            // rb.AddForce(MultiplyVector3(Camera.main.transform.TransformDirection(new Vector3(moveHorizontal, 0f, moveVertical).normalized).normalized, movespeed));
            rb.AddRelativeForce(MultiplyVector3(MultiplyVector3(new Vector3(moveHorizontal, 0f, moveVertical).normalized, movespeed), groundedModifier));
        }
        else
        {
            // rb.AddForce(MultiplyVector3(MultiplyVector3(Camera.main.transform.TransformDirection(new Vector3(moveHorizontal, 0f, moveVertical).normalized).normalized, movespeed), midairModifier));
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
                healthSlider.value = 100f * (jetpackMeter / jetpackMeterLimit);
                if (jetpackMeter < 0)
                {
                    jetpackMeter = 0;
                }
            }
        } else if (jetpackMeter < jetpackMeterLimit)
        {
            jetpackMeter += jetpackRecoveryRate;
            healthSlider.value = 100f * (jetpackMeter / jetpackMeterLimit);
        }


        if (movementRotation.sqrMagnitude > 0.1f && isGrounded)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementRotation), 1F);
        }
    }
}

