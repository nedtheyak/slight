using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour {

    public float maxScale = 2f;
    public float timer = 0f;
    public SphereCollider ownCollider;

	// Use this for initialization
	void Start () {
        ownCollider = this.gameObject.GetComponent<Collider>() as SphereCollider;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Enemy(Clone)")
        {
            Destroy(collider.gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        transform.localScale = new Vector3(timer * maxScale, timer * maxScale, timer * maxScale);
        (ownCollider).radius = timer * (maxScale / 2);            // Something about this seems off, the hitbox seems too big
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            Destroy(this.gameObject);
        }
	}
}
