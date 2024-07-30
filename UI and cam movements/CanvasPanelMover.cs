using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasPanelMover : MonoBehaviour
{
    public GameObject[] objectsToMove;       // Array of GameObjects to move
    public RectTransform canvasRect;         // Reference to the Canvas RectTransform
    public GameObject originPoint;           // Reference to the origin point GameObject
    public float speed = 100f;               // Speed at which the GameObject moves
    public float spawnDistance = 50f;        // Distance between spawned objects

    private int currentObjectIndex = 0;      // Index of the current GameObject in the array
    private Coroutine respawnCoroutine;      // Coroutine reference to manage the respawn timing

    [SerializeField] private int TextDelay = 58;


    void Start()
    {

    }


    void Update()
    {
        if (objectsToMove != null && objectsToMove.Length > 0)
        {
            GameObject currentObject = objectsToMove[currentObjectIndex];

            // Move the GameObject to the left
            currentObject.transform.Translate(Vector3.left * speed * Time.deltaTime);

            // Check if the GameObject is out of the canvas boundaries
            if (!IsObjectWithinCanvas(currentObject.GetComponent<RectTransform>()))
            {
                // Start the coroutine to respawn the object after 2 seconds
                if (respawnCoroutine == null)
                {
                    respawnCoroutine = StartCoroutine(RespawnObjectAfterDelay(TextDelay));
                }
            }
            else
            {
                // If the object is within the canvas, ensure any running coroutine is stopped
                if (respawnCoroutine != null)
                {
                    StopCoroutine(respawnCoroutine);
                    respawnCoroutine = null;
                }
            }
        }
    }

    bool IsObjectWithinCanvas(RectTransform objectRect)
    {
        Vector3[] objectCorners = new Vector3[4];
        objectRect.GetWorldCorners(objectCorners);
        Vector3[] canvasCorners = new Vector3[4];
        canvasRect.GetWorldCorners(canvasCorners);

        // Check if any of the object's corners are outside the canvas boundaries
        foreach (var corner in objectCorners)
        {
            if (corner.x < canvasCorners[0].x || corner.x > canvasCorners[2].x)
            {
                return false;
            }
        }
        return true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {

        }
    }

    void RespawnObject()
    {
        // Check if there are any objects in the array
        if (objectsToMove.Length == 0)
        {
            Debug.LogWarning("Object array is empty.");
            return;
        }

        // Reset the position of the current object to the origin point
        objectsToMove[currentObjectIndex].transform.position = originPoint.transform.position;

        // Increment the object index, looping back to the start if necessary
        currentObjectIndex = (currentObjectIndex + 1) % objectsToMove.Length;

        // Ensure the respawn coroutine is stopped if it was running
        if (respawnCoroutine != null)
        {
            StopCoroutine(respawnCoroutine);
            respawnCoroutine = null;
        }
    }

    IEnumerator RespawnObjectAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        RespawnObject();
    }

}
