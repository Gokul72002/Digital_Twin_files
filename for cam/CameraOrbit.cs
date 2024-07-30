using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform Origin; // The object around which the camera will orbit
    public float distance = 10f; // Initial distance from the object
    public float orbitSpeed = 1.5f; // Speed of orbiting
    public float scrollSpeed = 2f; // Speed of zooming in and out

    public float zoomMin = 20f; // Minimum zoom distance
    public float zoomMax = 200f; // Maximum zoom distance

    public bool activeClick = false; // Toggle for allowing rotation

    public float zoomStep = 20f; // Zoom step for button control
    public float horizontalOffset = 5f; // Horizontal offset for positioning

    private Vector3 currentRotation;
    private Vector3 desiredRotation;

    public float minVerticalAngle = 10f; // Minimum vertical angle (degrees)
    public float maxVerticalAngle = 80f; // Maximum vertical angle (degrees)

    void Start()
    {
        if (Origin != null)
        {
            // Initialize the current rotation based on the initial camera position
            Vector3 direction = (transform.position - Origin.position).normalized;
            currentRotation = Quaternion.LookRotation(direction).eulerAngles;
            desiredRotation = currentRotation;
        }
    }

    void Update()
    {
        HandleMouseInput();
        HandleScrollInput();
        UpdateCameraPosition();
    }

    private void HandleMouseInput()
    {
        if (Input.GetMouseButton(0) && activeClick)
        {
            // Update the desired rotation based on mouse input
            float horizontalInput = Input.GetAxis("Mouse X") * orbitSpeed;
            float verticalInput = -Input.GetAxis("Mouse Y") * orbitSpeed;
            desiredRotation.y += horizontalInput;
            desiredRotation.x += verticalInput;

            // Clamp the vertical rotation angle to avoid going below or above the allowed range
            desiredRotation.x = Mathf.Clamp(desiredRotation.x, minVerticalAngle, maxVerticalAngle);
        }
    }

    private void HandleScrollInput()
    {
        // Adjust the distance based on mouse scroll input
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        distance -= scrollInput * scrollSpeed;
        distance = Mathf.Clamp(distance, zoomMin, zoomMax); // Clamp the distance to a reasonable range
    }

    private void UpdateCameraPosition()
    {
        // Smoothly interpolate to the desired rotation
        currentRotation = Vector3.Lerp(currentRotation, desiredRotation, Time.deltaTime * orbitSpeed);

        // Calculate the new camera position
        Quaternion rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, 0);
        Vector3 offset = new Vector3(0, 0, -distance);
        Vector3 newPosition = Origin.position + rotation * offset;

        // Apply horizontal offset to the camera's position
        Vector3 horizontalOffsetVector = transform.right * horizontalOffset;
        transform.position = newPosition + horizontalOffsetVector;

        // Ensure the camera looks at the Origin
        transform.LookAt(Origin);
    }

    public void ZoomIn()
    {
        distance = Mathf.Clamp(distance - zoomStep, zoomMin, zoomMax);
    }

    public void ZoomOut()
    {
        distance = Mathf.Clamp(distance + zoomStep, zoomMin, zoomMax);
    }

    public void ToggleRotation()
    {
        activeClick = !activeClick; // Toggle the activeClick flag
    }
}