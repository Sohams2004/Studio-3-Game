using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ashtray : MonoBehaviour
{
     public float interactionDistance = 3f; // Adjust as necessary
    public Transform interactionText; // Assign the 3D Text transform in the Inspector
    public LayerMask interactableLayer; // Assign the layer of interactable objects

    void Start()
    {
        interactionText.gameObject.SetActive(false); // Hide the interaction text initially
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance, interactableLayer))
        {
            if (hit.collider.CompareTag("Ashtray"))
            {
                interactionText.position = hit.transform.position + Vector3.up * 0.5f; // Adjust the position of the text as needed
                interactionText.gameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.F))
                {
                    // Play the interaction sound from the ashtray
                    AudioSource audioSource = hit.collider.GetComponent<AudioSource>();
                    if (audioSource != null)
                    {
                        audioSource.Play();
                    }
                    // Additional interaction logic can go here
                }
            }
            else
            {
                interactionText.gameObject.SetActive(false);
            }
        }
        else
        {
            interactionText.gameObject.SetActive(false);
        }
    }
}
