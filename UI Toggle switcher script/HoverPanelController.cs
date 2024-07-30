using UnityEngine;
using UnityEngine.UI;

public class HoverPanelController : MonoBehaviour
{
    public GameObject hoverPanel; // Assign your panel in the Inspector

    void Start()
    {
        if (hoverPanel != null)
        {
            hoverPanel.SetActive(false); // Ensure the panel is hidden at the start
        }
    }

    void OnMouseEnter()
    {
        if (hoverPanel != null)
        {
            hoverPanel.SetActive(true); // Show the panel when the mouse enters the object
        }
    }

    void OnMouseExit()
    {
        if (hoverPanel != null)
        {
            hoverPanel.SetActive(false); // Hide the panel when the mouse exits the object
        }
    }
}
