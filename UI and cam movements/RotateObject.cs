using UnityEngine;

public class RotateObject : MonoBehaviour
{
    // Current speed of rotation in degrees per second
    private float rotationSpeed = 0f;

    // Target speed of rotation
    public float targetRotationSpeed = 0f;

    // Speed at which the rotation speed changes
    public float smoothTime = 0.5f; // Time it takes to reach the target speed
    private float rotationVelocity = 0f;

    void Update()
    {
        // Gradually change the rotation speed towards the target speed using SmoothDamp
        rotationSpeed = Mathf.SmoothDamp(rotationSpeed, targetRotationSpeed, ref rotationVelocity, smoothTime);

        // Rotate the object around the Z-axis at the specified speed
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    // Method to toggle the rotation speed
    public void ToggleRotation(bool isOn)
    {
        // Set the target rotation speed based on the toggle state
        targetRotationSpeed = isOn ? 500f : 0f;
    }
}
