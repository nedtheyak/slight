/// This script handles the global game timer


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class GameTimerController : MonoBehaviour {

    // Variables
    // The timer float itself
    public float timer;
    
    // The timer textbox's text component
    public Text timerCounter;

    // The pointHandler and its text component and script
    public GameObject pointHandler;
    public Text pointCounterText;
    public PointsHandlerController pointsHandlerScript;

    // EnemySpawnerHandler script, so spawning can be stopped when the timer is done
    public EnemySpawnerHandlerController enemySpawnerHandlerScript;

    // Initialization
    void Start () {
        timer = 100f;
        timerCounter = GameObject.Find("TimerCounter").GetComponent<Text>();
        pointHandler = GameObject.Find("PointsHandler");
        pointCounterText = GameObject.Find("PointCounter").GetComponent<Text>();
        pointsHandlerScript = pointHandler.GetComponent<PointsHandlerController>();
        enemySpawnerHandlerScript = GameObject.Find("EnemySpawnerHandler").GetComponent<EnemySpawnerHandlerController>();
    }
	
	// Constantly reduce timer until it is done, then stop spawning and display points
	void Update () {
		if (timer > 0f)
        {
            // Reduce timer
            timer -= Time.deltaTime;
            
            // Update timer display
            timerCounter.text = ((int)timer).ToString();
        }
        else
        {
            // Disallow editing points
            pointsHandlerScript.pointsEditable = false;

            // Stop enemy spawning
            enemySpawnerHandlerScript.spawnMore = false;
            enemySpawnerHandlerScript.stopSpawning = true;

            // Remove crosshair
            Destroy(GameObject.Find("Crosshair"));

            // Move PointCounter into center
            pointCounterText.rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
            pointCounterText.rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
            pointCounterText.rectTransform.pivot = new Vector2(0.5f, 0.5f);
            pointCounterText.alignment = TextAnchor.MiddleCenter;

            // Enlarge PointCounter text
            pointCounterText.fontSize = 45;
        }
	}
}
