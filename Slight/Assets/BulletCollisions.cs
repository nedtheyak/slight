using UnityEngine;
using UnityEngine.UI;
using System;

public class BulletCollisions : MonoBehaviour {
    public GameObject debugTextBox;
    public Text debugText;

    void Start()
    {
        debugTextBox = GameObject.Find("DebugTextBox");
        debugText = debugTextBox.GetComponent("Text") as Text;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger && !(other.name == "Player"))
        {
            // Do stuff
            debugText.text = other.name;
            if (other.name == "Enemy")
            {
                Destroy(other.gameObject);
            }

            // Destroy self
            Destroy(this.gameObject);
        }
    }
}
