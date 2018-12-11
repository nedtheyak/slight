/// This script handles collisions of legacy bullets


using UnityEngine;
using UnityEngine.UI;
using System;

public class BulletCollisions : MonoBehaviour {
    public GameObject debugTextBox;
    public Text debugText;

    void Start()
    {
        // Get the text box used for debugging and its Text component
        debugTextBox = GameObject.Find("DebugTextBox");
        debugText = debugTextBox.GetComponent("Text") as Text;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger && !(other.name == "Player(Clone)"))
        {
            // Set debug text to name of collider that was hit
            debugText.text = other.name;
            if (other.name == "Enemy(Clone)")
            {
                // Destroy hit collider's associated gameObject
                Destroy(other.gameObject);
            }

            // Destroy this associated bullet
            Destroy(this.gameObject);
        }
    }
}
