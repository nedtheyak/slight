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

    // Other variables
    public AudioManager audioManager;

    // Initialization
    void Start () {
        timer = 100f;
        timerCounter = GameObject.Find("TimerCounter").GetComponent<Text>();
        pointHandler = GameObject.Find("PointsHandler");
        pointCounterText = GameObject.Find("PointCounter").GetComponent<Text>();
        pointsHandlerScript = pointHandler.GetComponent<PointsHandlerController>();
        enemySpawnerHandlerScript = GameObject.Find("EnemySpawnerHandler").GetComponent<EnemySpawnerHandlerController>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
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

            // Play sound effects
            int tempPoints = pointsHandlerScript.totalPoints;
            if (tempPoints > 10)
            {
                if (tempPoints < 20)
                {
                    tempPoints = 10;
                }
                else
                {
                    tempPoints = 20;
                }
            }

            switch (tempPoints)
            {
                case 1:
                    audioManager.Play("FirstBlood");
                    break;
                case 2:
                    audioManager.Play("DoubleKill");
                    break;
                case 3:
                    audioManager.Play("TripleKill");
                    break;
                case 4:
                    audioManager.Play("UltraKill");
                    break;
                case 5:
                    audioManager.Play("Rampage");
                    break;
                case 6:
                    audioManager.Play("Unstoppable");
                    break;
                case 7:
                    audioManager.Play("WickedSick");
                    break;
                case 8:
                    audioManager.Play("MonsterKill");
                    break;
                case 9:
                    audioManager.Play("Godlike");
                    break;
                case 10:
                    audioManager.Play("Ownage");
                    break;
                case 20:
                    audioManager.Play("BeyondGodlike");
                    break;
                default:
                    audioManager.Play("TimeExpired");
                    break;
            }
        }
	}
}
