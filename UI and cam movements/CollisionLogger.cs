using UnityEngine;

public class CollisionLogger : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collider that we collided with has the tag "ScrollEnd"
        if (collision.gameObject.CompareTag("ScrollEnd"))
        {
            // Print "Works" to the console
            Debug.Log("Works");
        }
    }
}
