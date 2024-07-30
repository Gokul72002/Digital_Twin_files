using UnityEngine;
using UnityEngine.UI;

public class BlinkImage : MonoBehaviour
{
    [SerializeField] private Image image; // Reference to the Image component
    [SerializeField] private float blinkInterval = 0.5f; // Interval in seconds between blinks

    private float timer;

    void Start()
    {
        if (image == null)
        {
            image = GetComponent<Image>();
        }

        timer = blinkInterval; // Initialize the timer
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            image.enabled = !image.enabled; // Toggle the image's visibility
            timer = blinkInterval; // Reset the timer
        }
    }
}
