using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatToastBurned : MonoBehaviour
{
    public string interactionKey = "E";  // Key to interact with the burned toast
    public AudioClip eatSound;  // Sound to play when the toast is eaten
    public LayerMask interactableLayer;  // Layer mask for interactable objects

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(interactionKey))
        {
            CheckForBurnedToast();
        }
    }

    void CheckForBurnedToast()
    {
        RaycastHit hit;
        Vector3 rayOrigin = transform.position + transform.forward;  // Adjust the ray origin slightly forward
        if (Physics.Raycast(rayOrigin, transform.forward, out hit, Mathf.Infinity, interactableLayer))
        {
            Debug.Log("Raycast hit: " + hit.collider.name);  // Debug statement to check what the raycast hits

            if (hit.collider.CompareTag("BurnedToast"))
            {
                Debug.Log("Burned toast detected!");  // Debug statement for toast detection

                Destroy(hit.collider.gameObject);
                if (eatSound != null)
                {
                    audioSource.PlayOneShot(eatSound);
                }
                // Update UI or other game elements here if needed
            }
        }
    }

    
}
