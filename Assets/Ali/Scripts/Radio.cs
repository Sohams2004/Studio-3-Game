using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    public float raycastDistance = 5f;  // Distance for the raycast
    public LayerMask interactableLayer;  // Layer for interactable objects

    private AudioSource audioSource;
    private bool isMuted = false;

    private void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found on this GameObject.");
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))  // Check for left mouse button click
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, raycastDistance, interactableLayer))
            {
                // Check if the object hit is the radio
                if (hit.collider.CompareTag("Radio"))
                {
                    ToggleSound();
                }
            }
        }
    }

    private void ToggleSound()
    {
        if (audioSource == null) return;

        if (audioSource.isPlaying)
        {
            if (isMuted)
            {
                audioSource.mute = false;  // Unmute the sound
                isMuted = false;
            }
            else
            {
                audioSource.mute = true;  // Mute the sound
                isMuted = true;
            }
        }
        else
        {
            audioSource.Play();  // Play the sound if it is not playing
            isMuted = false;
        }
    }
}
