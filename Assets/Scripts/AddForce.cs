using UnityEngine;

public class AddForce : MonoBehaviour
{
    public TrashManager trashManager;
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
            // Do not change this back to -transform.forward, because that pushes the
            // object where it is facing, not where the conveyor is facing
            Vector3 movementDirection = -collision.gameObject.transform.forward;  // Direction the belt moves
            rb.velocity = movementDirection * trashManager.trashSpeed;
        }
    }
}
