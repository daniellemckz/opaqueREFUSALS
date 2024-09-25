using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundary : MonoBehaviour
{
    public float minX = -461f; // Minimum X boundary
    public float maxX = 888f;  // Maximum X boundary
    public float minZ = -235f; // Minimum Z boundary
    public float maxZ = 1053f;  // Maximum Z boundary

    private Transform playerTransform;

    void Start()
    {
        playerTransform = transform;
    }

    void Update()
    {
        // Get the current position
        Vector3 clampedPosition = playerTransform.position;

        // Clamp the X and Z positions
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        clampedPosition.z = Mathf.Clamp(clampedPosition.z, minZ, maxZ);

        // Apply the clamped position back to the player
        playerTransform.position = clampedPosition;
    }
}
