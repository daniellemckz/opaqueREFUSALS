using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnPlayerEnter : MonoBehaviour
{
    public float rotationSpeed = 50f;
    private bool isPlayerOnTop = false;

    void Update()
    {
        if (isPlayerOnTop)
        {
            // Rotate the object continuously
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            // Player is on top of the object, start rotating
            isPlayerOnTop = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            // Player has exited the object, stop rotating
            isPlayerOnTop = false;
        }
    }
}

