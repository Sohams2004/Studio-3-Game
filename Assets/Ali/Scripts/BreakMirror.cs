/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakMirror : MonoBehaviour
{
     public GameObject objectToEnable; // Reference to the object you want to enable
    public string mirrorTag = "Mirror"; // Tag of the mirror object
    public float lookTimeRequired = 3f; // Time required to look at the mirror in seconds
    public AudioClip activationSound; // Sound to play when object is enabled

    private float lookTimer; // Timer to track how long the player has been looking
    private bool isLooking; // Flag to track if the player is looking at the mirror

    void Update()
    {
        // Check if the player is looking at an object with the specified tag
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hitInfo))
        {
            GameObject hitObject = hitInfo.collider.gameObject;
            
            // Check if the hit object has the specified tag and if we're not already looking
            if (hitObject.CompareTag(mirrorTag) && !isLooking)
            {
                lookTimer += Time.deltaTime; // Increment timer while looking at the mirror

                // Check if the player has looked for the required time
                if (lookTimer >= lookTimeRequired)
                {
                    EnableObject(); // Call function to enable the object
                }
            }
            else
            {
                // Reset timer if the player looks away from the mirror
                lookTimer = 0f;
                isLooking = false;
            }
        }
    }

    void EnableObject()
    {
        objectToEnable.SetActive(true); // Enable the specified object
        
        // Play activation sound if specified
        if (activationSound != null)
        {
            AudioSource.PlayClipAtPoint(activationSound, objectToEnable.transform.position);
        }
        
        // Add any additional actions you want to perform when the object is enabled
    }
}
*/