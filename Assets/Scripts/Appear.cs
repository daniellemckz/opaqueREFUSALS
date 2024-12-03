using UnityEngine;

public class ObjectAppearanceOnRigInactive : MonoBehaviour
{
    // Assign the rig and the object to appear in the Inspector
    public GameObject rig;          // The rig to monitor
    public GameObject objectToAppear; // The object to appear when rig is inactive

    void Update()
    {
        // Check if the rig is no longer active
        if (!rig.activeInHierarchy && !objectToAppear.activeInHierarchy)
        {
            // Activate the object to appear
            objectToAppear.SetActive(true);
        }
    }
}
