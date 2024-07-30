using UnityEngine;

public class RotateObjectWithMouse : MonoBehaviour
{
    public float rotationSpeed = 100f; // Speed of rotation
    public float minRotationY = -45f; // Minimum Y-axis rotation angle
    public float maxRotationY = 45f; // Maximum Y-axis rotation angle
    public float smoothTime = 0.1f; // Time for the smooth transition

    private bool isDragging = false; // Flag to check if the object is being dragged
    private Vector3 lastMousePosition;
    private Quaternion targetRotation;
    private float rotationVelocity;

    void Start()
    {
        targetRotation = transform.rotation;
        Debug.Log("Initial target rotation: " + targetRotation.eulerAngles);
    }

    void Update()
    {
        // Check if the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            // Set the dragging flag to true
            isDragging = true;
            lastMousePosition = Input.mousePosition;
            Debug.Log("Mouse button pressed. Starting drag.");
        }

        // Check if the left mouse button is released
        if (Input.GetMouseButtonUp(0))
        {
            // Set the dragging flag to false
            isDragging = false;
            Debug.Log("Mouse button released. Stopping drag.");
        }

        // Rotate the object if it is being dragged
        if (isDragging)
        {
            // Calculate the difference in mouse position
            Vector3 delta = Input.mousePosition - lastMousePosition;

            // Apply rotation around the Y-axis (horizontal mouse movement)
            float rotationY = delta.x * rotationSpeed * Time.deltaTime;

            // Get the current rotation
            Vector3 currentRotation = transform.eulerAngles;

            // Apply the new rotation and clamp it
            currentRotation.y += rotationY;
            currentRotation.y = Mathf.Clamp(currentRotation.y, minRotationY, maxRotationY);

            // Set the target rotation
            targetRotation = Quaternion.Euler(currentRotation);

            // Update the last mouse position
            lastMousePosition = Input.mousePosition;

            Debug.Log("Dragging. Current rotation: " + currentRotation);
        }

        // Smoothly rotate towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothTime * Time.deltaTime);
        Debug.Log("Slerping to target rotation: " + targetRotation.eulerAngles);
    }
}
