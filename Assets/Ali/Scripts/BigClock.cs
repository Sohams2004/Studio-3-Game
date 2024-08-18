using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BigClock : MonoBehaviour
{
    public float interactionDistance = 3f; 
    public Transform interactionText; 
    public LayerMask interactableLayer; 

    void Start()
    {
        interactionText.gameObject.SetActive(false); 
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance, interactableLayer))
        {
            if (hit.collider.CompareTag("Clock"))
            {
                interactionText.gameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    AudioSource audioSource = hit.collider.GetComponent<AudioSource>();
                    if (audioSource != null)
                    {
                        audioSource.Play();
                    }
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
