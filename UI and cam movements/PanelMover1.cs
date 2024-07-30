using UnityEngine;

public class PanelMover1 : MonoBehaviour
{
    public RectTransform panelTransform; // Reference to the panel's RectTransform
    public GameObject startObject; // Reference to the GameObject for the starting position
    public float moveSpeed = 200f; // Speed at which the panel moves
    private Vector2 startPosition; // The starting position of the panel

    public bool resetMovement; // Boolean to control the resetting of the panel's position

    void Start()
    {
        // Set the panel's initial position using the position of the startObject
        startPosition = startObject.GetComponent<RectTransform>().anchoredPosition;
        panelTransform.anchoredPosition = startPosition;
    }

    void Update()
    {
        if (resetMovement)
        {
            ResetMovement();
            resetMovement = false; // Reset the boolean to avoid continuous resetting
        }
        else
        {
            // Move the panel to the left
            panelTransform.anchoredPosition += Vector2.left * moveSpeed * Time.deltaTime;
        }
    }

    public void ResetMovement()
    {
        // Reset the panel's position to the start position
        panelTransform.anchoredPosition = startPosition;
    }
}
