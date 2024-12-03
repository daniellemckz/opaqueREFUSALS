using UnityEngine;

public class RotateOnTopCollision : MonoBehaviour
{
    public float rotationSpeed = 100f;
    private bool isPlayerOnTop = false;

    void Update()
    {
        if (isPlayerOnTop)
        {
            // Rotate the object around the Y-axis
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Check if the player is on top by verifying the contact point's normal
            foreach (ContactPoint contact in collision.contacts)
            {
                Vector3 contactNormal = contact.normal;

                // Only set isPlayerOnTop if the contact normal is approximately downward relative to the object
                if (Vector3.Dot(contactNormal, Vector3.up) > 0.9f)
                {
                    isPlayerOnTop = true;
                    return; // Exit once we find a valid top contact
                }
            }

            // If no valid top contact point is found, set isPlayerOnTop to false
            isPlayerOnTop = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnTop = false;
        }
    }
}

