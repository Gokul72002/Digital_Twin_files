using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float zoomSpeed = 10f; // Speed of zooming
    public float minFOV = 15f; // Minimum field of view
    public float maxFOV = 90f; // Maximum field of view

    void Update()
    {
        // Get the scroll input
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        // If there's any scroll input, adjust the field of view
        if (scrollInput != 0)
        {
            // Adjust the field of view (FOV) based on scroll input
            float newFOV = Camera.main.fieldOfView - scrollInput * zoomSpeed;
            Camera.main.fieldOfView = Mathf.Clamp(newFOV, minFOV, maxFOV);

        }
    }
}
