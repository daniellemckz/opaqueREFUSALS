using UnityEngine;

public class DisappearOnCollision : MonoBehaviour
{
    // Tag your first-person controller with this tag in the Inspector
    public string playerTag = "Player";

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has the correct tag
        if (collision.gameObject.CompareTag(playerTag))
        {
            // Make the game object disappear
            gameObject.SetActive(false);
        }
    }
}
