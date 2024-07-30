using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed;
    public Transform orientation;
    public VariableJoystick variableJoystick;

    private float HorizontalInput;
    private float VerticalInput;

    public GameObject playerTransform;

    /*private Vector3 initialPosition;
    private Quaternion initialRotation;*/

    private Vector3 moveDirection;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        // Store the initial position and rotation
       /* initialPosition = transform.position;
        initialRotation = transform.rotation;*/
    }

    void Update()
    {
        myInput();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    private void myInput()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        VerticalInput = Input.GetAxisRaw("Vertical");

        /*HorizontalInput = variableJoystick.Horizontal;
        VerticalInput = variableJoystick.Vertical;
*/    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * VerticalInput + orientation.right * HorizontalInput;
        rb.AddForce(moveDirection.normalized * MovementSpeed * 10f, ForceMode.Force);
    }

    // Function to reset the player's transform to the initial position
    public void ResetTransform()
    {

        if (playerTransform != null)
        {
            transform.position = playerTransform.transform.position;
            transform.rotation = playerTransform.transform.rotation;
        }

        /*transform.position = initialPosition;
        transform.rotation = initialRotation;*/

        // Optionally, reset the velocity if needed
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
