/// This script handles the PointsHandler interactions


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PointsHandlerController : MonoBehaviour {

    // Variables
    public int totalPoints;
    public Text pointCounterText;
    public bool pointsEditable;


    // Function for adding points
    public void AddPoints(int pointsToAdd) {
        if (pointsEditable)
        {
            // Add the points
            totalPoints += pointsToAdd;

            // Update the point counter
            pointCounterText.text = "Points: " + totalPoints.ToString();
        }
    }
    
	// Initialization
	void Start () {
        pointsEditable = true;
        totalPoints = 0;
        pointCounterText = GameObject.Find("PointCounter").GetComponent<Text>();
        pointCounterText.text = "Points: " + totalPoints.ToString();
    }
}
