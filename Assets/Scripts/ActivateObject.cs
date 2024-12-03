using UnityEngine;

public class ActivateObjectOnDisable : MonoBehaviour
{
    // Assign the object to appear when the rig is deactivated
    public GameObject objectToAppear;

    void OnDisable()
    {
        // Check if the objectToAppear exists, then activate it
        if (objectToAppear != null)
        {
            objectToAppear.SetActive(true);
        }
    }
}
