using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    public float raycastDistance = 5f;  
    public LayerMask interactableLayer;  

    private AudioSource audioSource;
    private bool isMuted = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found on this GameObject.");
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))  
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, raycastDistance, interactableLayer))
            {
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
                audioSource.mute = false;  
                isMuted = false;
            }
            else
            {
                audioSource.mute = true;  
                isMuted = true;
            }
        }
        else
        {
            audioSource.Play();  
            isMuted = false;
        }
    }
}
