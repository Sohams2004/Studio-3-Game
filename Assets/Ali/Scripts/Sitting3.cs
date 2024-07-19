using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sitting3 : MonoBehaviour
{
    public Animator playerAnimator;  // Drag your Animator component here in the Inspector
    public Transform sittingPoint;   // Drag your sitting point here in the Inspector
    public KeyCode sitKey = KeyCode.E; // Key to sit and stand up

    private bool isSitting = false;   // To track if the player is currently sitting
    private Vector3 originalPosition; // To store the original position of the player
    private Quaternion originalRotation; // To store the original rotation of the player

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player enters a chair collider
        if (other.CompareTag("Chair") && !isSitting)
        {
            SitOnChair();
        }
    }

    private void Update()
    {
        // Check for the key press to stand up
        if (isSitting && Input.GetKeyDown(sitKey))
        {
            StandUp();
        }
    }

    private void SitOnChair()
    {
        // Save the original position and rotation of the player
        originalPosition = transform.position;
        originalRotation = transform.rotation;

        // Set the player’s position to the sitting point
        transform.position = sittingPoint.position;
        transform.rotation = sittingPoint.rotation;

        // Trigger the sitting animation
        playerAnimator.SetTrigger("Sit");

        // Disable player controls here if needed (e.g., movement)
        // Example: GetComponent<PlayerMovement>().enabled = false;

        isSitting = true;
    }

    private void StandUp()
    {
        // Reset the player’s position and rotation to the original values
        transform.position = originalPosition;
        transform.rotation = originalRotation;

        // Trigger the standing up animation (or reset to idle)
        playerAnimator.SetTrigger("StandUp");

        // Re-enable player controls here if they were disabled
        // Example: GetComponent<PlayerMovement>().enabled = true;

        isSitting = false;
    }
}
