using UnityEngine;
using TMPro; // For TextMeshPro

public class TriggerMessage : MonoBehaviour
{
    public TextMeshProUGUI messageText; // Drag and drop your TextMeshProUGUI here
    public string messageToShow = "You've collided with the object!";
    public float messageDuration = 2f; // Duration for which the message will be shown

    private void Start()
    {
        // Hide the message at the start
        messageText.gameObject.SetActive(false);
    }

    // For trigger collisions, use this instead:
    private void OnTriggerEnter(Collider other)

    {
        Debug.Log("Trigger Detected with: " + other.gameObject.name);
        if (other.CompareTag("TargetObject"))

        {
            ShowMessage();
        }

    }

    void ShowMessage()
    {
        Debug.Log("Message Triggered");
        messageText.text = messageToShow; // Set the message text
        messageText.gameObject.SetActive(true); // Show the message

        // Hide the message after the set duration
        Invoke("HideMessage", messageDuration);
    }

    void HideMessage()
    {
        messageText.gameObject.SetActive(false); // Hide the message after the duration
    }
}