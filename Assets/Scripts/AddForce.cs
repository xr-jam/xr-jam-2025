using UnityEngine;

public class AddForce : MonoBehaviour
{
    public float surfaceSpeed = 1f;  // Speed of surface movement
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb)
            rb.freezeRotation = true;
    }

    void OnCollisionStay(Collision collision)
    {
        // Check if the object is in contact with the moving surface
        if (collision.gameObject.CompareTag("ConveyorBelt"))
        {
            // Apply force in the direction of the surface movement
            Vector3 movementDirection = -transform.forward;  // Direction the belt moves
            rb.velocity = movementDirection * surfaceSpeed * 2.05f;
        }
    }
}
