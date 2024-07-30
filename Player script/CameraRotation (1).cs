using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float SenX;
    public float SenY;

    public Transform Orientation;

    float XRotation;
    float YRotation;



    void Start()
    {
        /*Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;*/

    }
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * SenX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * SenY;

        YRotation += mouseX;
        XRotation -= mouseY;

        XRotation = Mathf.Clamp(XRotation, -50f, 50f);

        transform.rotation = Quaternion.Euler(XRotation, YRotation,0);
        Orientation.rotation = Quaternion.Euler(0, YRotation, 0);   
    }
}