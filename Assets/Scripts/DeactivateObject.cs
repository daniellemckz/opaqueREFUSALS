using UnityEngine;

public class DeactivateAfterTime : MonoBehaviour
{
    // Set this in the Inspector to define how long the object should stay active
    public float delayTime = 5f; // default is 5 seconds

    void Start()
    {
        // Start the deactivation process with a delay
        Invoke("DeactivateObject", delayTime);
    }

    // Function to deactivate the object
    void DeactivateObject()
    {
        gameObject.SetActive(false);
    }
}
