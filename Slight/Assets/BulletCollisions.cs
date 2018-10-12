using UnityEngine;

public class BulletCollisions : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger)
        {
            // Do stuff
            Destroy(this.gameObject);
        }
    }
}
