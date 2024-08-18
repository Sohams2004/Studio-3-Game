using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatToastBurned : MonoBehaviour
{
    public string interactionKey = "E";  
    public AudioClip eatSound;  
    public LayerMask interactableLayer;  

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
        Vector3 rayOrigin = transform.position + transform.forward;  
        if (Physics.Raycast(rayOrigin, transform.forward, out hit, Mathf.Infinity, interactableLayer))
        {
            Debug.Log("Raycast hit: " + hit.collider.name);  

            if (hit.collider.CompareTag("BurnedToast"))
            {
                Debug.Log("Burned toast detected!");  

                Destroy(hit.collider.gameObject);
                if (eatSound != null)
                {
                    audioSource.PlayOneShot(eatSound);
                }
            }
        }
    }

    
}
