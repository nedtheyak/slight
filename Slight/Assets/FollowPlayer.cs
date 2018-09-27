using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public GameObject player;
    public Vector3 offset;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        offset = new Vector3(0, 1, 0);
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position + offset;
	}
}
