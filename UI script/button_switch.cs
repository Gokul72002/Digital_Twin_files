using UnityEngine;
using UnityEngine.UI;

public class ButtonSwitch : MonoBehaviour
{
    public Button[] pauseButtons; // Array of pause buttons
    public Button[] resumeButtons; // Array of resume buttons

    void Start()
    {
        // Ensure the arrays are of the same length
        if (pauseButtons.Length != resumeButtons.Length)
        {
            Debug.LogError("Pause and Resume button arrays must be of the same length.");
            return;
        }

        // Add listeners to the buttons and initially hide all resume buttons
        for (int i = 0; i < pauseButtons.Length; i++)
        {
            int index = i; // Local copy of the index for the listener
            pauseButtons[i].onClick.AddListener(() => Pause(index));
            resumeButtons[i].onClick.AddListener(() => Resume(index));

            // Initially hide the resume buttons
            resumeButtons[i].gameObject.SetActive(false);
        }
    }

    void Pause(int index)
    {
        Time.timeScale = 0f; // Pause the game
        pauseButtons[index].gameObject.SetActive(false); // Hide pause button
        resumeButtons[index].gameObject.SetActive(true); // Show resume button
    }

    void Resume(int index)
    {
        Time.timeScale = 1f; // Resume the game
        pauseButtons[index].gameObject.SetActive(true); // Show pause button
        resumeButtons[index].gameObject.SetActive(false); // Hide resume button
    }
}
