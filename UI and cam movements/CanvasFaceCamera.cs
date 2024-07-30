using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CanvasFaceCamera : MonoBehaviour
{


    public Camera topCam;
    public Camera fpCam;

    public GameObject[] panels; // Reference to the target GameObject array

    public float minScale = 0.42f; // Minimum scale
    public float midScale = 0.62f; // Mid scale
    public float maxScale = 1.0f;  // Maximum scale
    public float maxDistance = 20f; // Distance at which the scale is max
    public float minDistance = 5f;  // Distance at which the scale is min

    private Camera currentCam;

    void Start()
    {
        // Set the initial camera (assuming top camera is the default)
        SwitchToTopCam();
    }

    void Update()
    {
        if (currentCam != null)
        {
            // Make each panel face the current camera and adjust its size
            foreach (var panel in panels)
            {
                if (panel != null)
                {
                    // Make the panel face the current camera
                    panel.transform.LookAt(panel.transform.position + currentCam.transform.rotation * Vector3.forward,
                                           currentCam.transform.rotation * Vector3.up);

                    // Adjust the panel size based on distance
                    AdjustObjectSize(panel);
                }
                else
                {
                    Debug.LogWarning("One of the target objects is not assigned.");
                }
            }
        }
    }

    public void SwitchToTopCam()
    {
        if (topCam != null)
        {
            currentCam = topCam;

        }
        else
        {
            Debug.LogWarning("Top camera is not assigned.");
        }
    }

    public void SwitchToFPCam()
    {
        if (fpCam != null)
        {
            currentCam = fpCam;

        }
        else
        {
            Debug.LogWarning("First-person camera is not assigned.");
        }
    }

    private void AdjustObjectSize(GameObject panel)
    {
        float distance = Vector3.Distance(panel.transform.position, currentCam.transform.position);
        float t = Mathf.InverseLerp(minDistance, maxDistance, distance);
        float scale = Mathf.Lerp(minScale, maxScale, t);
        panel.transform.localScale = new Vector3(scale, scale, scale);
    }

    private IEnumerator joy()
    {
        yield return new WaitForSeconds(.3f);
        SwitchToFPCam();
        
    }

    public void Calltpv()
    {
        StartCoroutine("joy");
    }
}
