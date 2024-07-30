using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    public float rotationSpeed = 5.0f; // Adjust this value to control rotation speed
    public float maxRotationAngle = 180.0f; // Adjust this value to set the maximum rotation angle

    public float currentRotationAngle = 0.0f;
    private Quaternion originalRotation;


    public bool disable = true;

    void Start()
    {
        // Store the original rotation when the script starts
        originalRotation = transform.rotation;
    }

    private void Update()
    {
        if (Input.GetMouseButton(1) && disable) // Check if the right mouse button is held down
        {
            float mouseX = Input.GetAxis("Mouse X"); // Get mouse X movement

            // Update the current rotation angle based on mouse movement
            currentRotationAngle += -mouseX * rotationSpeed;

            // Clamp the rotation angle to the specified limits
            currentRotationAngle = Mathf.Clamp(currentRotationAngle, -maxRotationAngle, maxRotationAngle);

            // Rotate the object based on the updated rotation angle
            transform.rotation = Quaternion.Euler(0, currentRotationAngle, 0);
        }


            // Reset the rotation to the original rotation
           // Reset the current rotation angle
        
    }
    public void Exiting()
    {
        transform.rotation = originalRotation;
        currentRotationAngle = 0.0f;
    }
}
