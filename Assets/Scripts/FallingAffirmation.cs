using UnityEngine;
using TMPro; // For TextMeshPro

public class TriggerMessage : MonoBehaviour
{
    public TextMeshProUGUI messageText; // Drag and drop your TextMeshProUGUI here
    public float messageDuration = 2f; // Duration for which the message will be shown

    // Public message fields that can be customized in the Unity Inspector
    public string firstCollisionMessage = "";
    public string secondCollisionMessage = "";
    public string thirdCollisionMessage = "";
    public string fourthCollisionMessage = "";
    public string fifthCollisionMessage = "";
    public string sixthCollisionMessage = "";
    public string seventhCollisionMessage = "";
    public string eighthCollisionMessage = "";
    public string ninthCollisionMessage = "";
    public string defaultCollisionMessage = "";

    private int collisionCount = 0; // Counter to track number of collisions

    private void Start()
    {
        // Hide the message at the start
        messageText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if we collided with the correct object
        if (other.CompareTag("TargetObject"))
        {
            collisionCount++; // Increment the collision counter
            ShowMessage(); // Show the appropriate message
        }
    }

    void ShowMessage()
    {
        // Determine which message to show based on the collision count
        switch (collisionCount)
        {
            case 1:
                messageText.text = firstCollisionMessage;
                break;
            case 2:
                messageText.text = secondCollisionMessage;
                break;
            case 3:
                messageText.text = thirdCollisionMessage;
                break;
            default:
                // Use the default message with the number of collisions
                messageText.text = string.Format(defaultCollisionMessage, collisionCount);
                break;
        }

        messageText.gameObject.SetActive(true); // Show the message
        Invoke("HideMessage", messageDuration); // Hide the message after a duration
    }

    void HideMessage()
    {
        messageText.gameObject.SetActive(false); // Hide the message after duration
    }
}
