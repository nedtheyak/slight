/// This script is for handling the Rail hitbox on the player


using UnityEngine;




public class RailBoxController : MonoBehaviour {

    // Variables
    public PlayerController playerControllerScript;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player(Clone)").GetComponent<PlayerController>();
    }
    
    void Update()
    {
        // If grinding, lock the player's velocity
        if (playerControllerScript.isGrinding)
        {
            Vector3 localizedVelocity = playerControllerScript.railTransform.InverseTransformVector(playerControllerScript.rb.velocity);
            localizedVelocity.x = 0f;
            localizedVelocity.z = 0f;
            //Debug.Log(playerControllerScript.railTransform.InverseTransformVector(playerControllerScript.rb.velocity));
            //Debug.Log(localizedVelocity.z);
            Debug.Log(playerControllerScript.railTransform.gameObject.name);
            playerControllerScript.rb.velocity = playerControllerScript.railTransform.TransformVector(localizedVelocity);
            // LOCAL Z = WORLD Y?
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (playerControllerScript.isGrinding)
        {
            if (other.name.StartsWith("Rail"))
            {
                // RELEASE CLAMP
                playerControllerScript.isGrinding = false;
                playerControllerScript.rb.velocity = new Vector3(playerControllerScript.rb.velocity.x, playerControllerScript.rb.velocity.y + 5f, playerControllerScript.rb.velocity.z);
            }
        }
    }
}
