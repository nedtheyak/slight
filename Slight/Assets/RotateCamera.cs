/// This script handles the rotation of the camera using mouse inputs


using UnityEngine;

public class RotateCamera : MonoBehaviour {

    // Variables
    Vector2 mouseLook;
    Vector2 smoothV;
    public float sensitivity = 5.0f;
    public float smoothing = 2f;

	
	void Update () {
        // Camera control with mouse
        

        // Get inputs
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        // Convert to scaled inputs (sensitivity & smoothing)
        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

        // Smooth inputs
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouseLook += smoothV;

        // Lock y axis from going further than straight up or down
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);

        // Apply rotations
        transform.localRotation = Quaternion.Euler(-mouseLook.y, mouseLook.x, 0f);
    }
}