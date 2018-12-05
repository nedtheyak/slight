using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimerController : MonoBehaviour {

    public float timer;
    public Text timerCounter;
    public GameObject pointHandler;
    public Text pointCounterText;
    public PointsHandlerController pointsHandlerScript;
    public EnemySpawnerHandlerController enemySpawnerHandlerScript;

    // Use this for initialization
    void Start () {
        timer = 100f;
        timerCounter = GameObject.Find("TimerCounter").GetComponent<Text>();
        pointHandler = GameObject.Find("PointsHandler");
        pointCounterText = GameObject.Find("PointCounter").GetComponent<Text>();
        pointsHandlerScript = pointHandler.GetComponent<PointsHandlerController>();
        enemySpawnerHandlerScript = GameObject.Find("EnemySpawnerHandler").GetComponent<EnemySpawnerHandlerController>();
    }
	
	// Update is called once per frame
	void Update () {
		if (timer > 0f)
        {
            timer -= Time.deltaTime;
            timerCounter.text = ((int)timer).ToString();
        }
        else
        {
            pointsHandlerScript.pointsEditable = false;
            enemySpawnerHandlerScript.spawnMore = false;
            enemySpawnerHandlerScript.stopSpawning = true;
            Destroy(GameObject.Find("Crosshair"));
            pointCounterText.rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
            pointCounterText.rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
            pointCounterText.rectTransform.pivot = new Vector2(0.5f, 0.5f);
            pointCounterText.alignment = TextAnchor.MiddleCenter;
            pointCounterText.fontSize = 45;
        }
	}
}
