using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class TopMostCanvas : MonoBehaviour
{
    private Canvas canvas;

    void Start()
    {
        canvas = GetComponent<Canvas>();

        // Set the sorting order to a high value
        canvas.sortingOrder = 1000;
    }
}
