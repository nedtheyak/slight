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
            playerControllerScript.rb.velocity = playerControllerScript.railTransform.TransformVector(localizedVelocity);
            // LOCAL Z = WORLD Y?
        }
    }

    public void StopGrinding()
    {
        playerControllerScript.isGrinding = false;
        playerControllerScript.audioManager.Stop("SkateGrind");
        playerControllerScript.rb.velocity = new Vector3(playerControllerScript.rb.velocity.x, playerControllerScript.rb.velocity.y + 10f, playerControllerScript.rb.velocity.z);
        playerControllerScript.audioManager.PlayOneShot("SkateKick");
    }

    private void OnTriggerExit(Collider other)
    {
        if (playerControllerScript.isGrinding)
        {
            if (other.name.StartsWith("Rail"))
            {
                StopGrinding();
            }
        }
    }
}
