using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorFixedCamera : MonoBehaviour
{
     public Camera playerCamera; // The main player camera
    public Camera otherCamera; // The camera to switch to
    public GameObject player; // The player GameObject

    private bool isSwitching = false; // To avoid multiple triggers

    void Start()
    {
        // Ensure this GameObject has a Collider component and it is set as a trigger
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.isTrigger = true; // Ensure it's a trigger
        }
        else
        {
            Debug.LogError("Collider component is missing on this GameObject.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isSwitching)
        {
            isSwitching = true;
            StartCoroutine(SwapCameraAndEnablePlayer());
        }
    }

    private IEnumerator SwapCameraAndEnablePlayer()
    {
        // Disable player and switch cameras
        if (player != null)
        {
            player.SetActive(false);
        }

        if (playerCamera != null)
        {
            playerCamera.gameObject.SetActive(false);
        }

        if (otherCamera != null)
        {
            otherCamera.gameObject.SetActive(true);
        }

        // Wait for 7 seconds
        yield return new WaitForSeconds(7f);

        // Switch back to player camera and enable player
        if (otherCamera != null)
        {
            otherCamera.gameObject.SetActive(false);
        }

        if (playerCamera != null)
        {
            playerCamera.gameObject.SetActive(true);
        }

        if (player != null)
        {
            player.SetActive(true);
        }

        // Ensure that the trigger collider does not trigger again
        isSwitching = false;
        // Optionally disable the collider to prevent further triggers
        GetComponent<Collider>().enabled = false;
    }
}
