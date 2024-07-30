using UnityEngine;
using UnityEngine.UI;

public class CameraSwitch : MonoBehaviour
{

    

    [Header("Visualizers")]
    public GameObject[] Shadercubes; // Array for Shadercube objects
    public GameObject[] heatmaps;    // Array for heatmap objects

    [Header("Cameras & Buttons")]
    public Camera camera1;
    public Camera camera2;
    public Button switchToCam1Button;
    public Button switchToCam2Button;

    [Header("Canvas & Positions")]
   /* public Canvas worldSpaceCanvas;
    public Canvas WorldSpaceHumitidy;
    public Transform camera2Position; */ // Position for camera 2 view

    private Vector3 originalCanvasPosition;  // Original position for camera 1 view

    void Start()
    {
     

        // Initialize the button click listeners
        switchToCam1Button.onClick.AddListener(SwitchToCamera1);
        switchToCam2Button.onClick.AddListener(SwitchToCamera2);

        // Ensure camera1 is active at the start
        camera1.enabled = true;
        camera2.enabled = false;

        // Store the original position of the canvas
/*        originalCanvasPosition = worldSpaceCanvas.transform.position;
        originalCanvasPosition = WorldSpaceHumitidy.transform.position;
*/    }

    // Top view
    void SwitchToCamera1()
    {
        camera1.enabled = true;
        camera2.enabled = false;

        // Activate all Shadercube objects
        foreach (var shadercube in Shadercubes)
        {
            shadercube.SetActive(true);
        }

        // Deactivate all heatmap objects
        foreach (var heatmap in heatmaps)
        {
            heatmap.SetActive(false);
        }

        // Move the canvas back to its original position
/*        worldSpaceCanvas.transform.position = originalCanvasPosition;
        WorldSpaceHumitidy.transform.position = originalCanvasPosition;
*/    }

    // FP view
    void SwitchToCamera2()
    {
        camera1.enabled = false;
        camera2.enabled = true;

        // Deactivate all Shadercube objects
        foreach (var shadercube in Shadercubes)
        {
            shadercube.SetActive(false);
        }

        // Activate all heatmap objects
        foreach (var heatmap in heatmaps)
        {
            heatmap.SetActive(true);
        }

        // Move the canvas to the new position
/*        worldSpaceCanvas.transform.position = camera2Position.position;
        WorldSpaceHumitidy.transform.position = camera2Position.position;
*/    }
   

}


