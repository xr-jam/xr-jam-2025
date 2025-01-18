using UnityEngine;
using System.Collections;

public class AddForce : MonoBehaviour
{
    public TrashManager trashManager;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb)
            rb.freezeRotation = true;
        StartCoroutine(PrintLocationEvery60Seconds());
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

    IEnumerator PrintLocationEvery60Seconds()
    {
        while (true) // Infinite loop for continuous printing
        {
            if (this != null)
            {
                Debug.Log($"Location of {gameObject.name}: {gameObject.transform.position}");
            }
            else
            {
                Debug.LogWarning("Target is not assigned!");
            }

            yield return new WaitForSeconds(1f); // Wait for 60 seconds
        }
    }
}
