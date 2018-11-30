using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsHandlerController : MonoBehaviour {

    public int totalPoints;
    public Text pointCounterText;


    public void AddPoints(int pointsToAdd) {
        totalPoints += pointsToAdd;
        pointCounterText.text = "Points: " + totalPoints.ToString();
    }


	// Use this for initialization
	void Start () {
        totalPoints = 0;
        pointCounterText = GameObject.Find("PointCounter").GetComponent<Text>();
        pointCounterText.text = "Points: " + totalPoints.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
