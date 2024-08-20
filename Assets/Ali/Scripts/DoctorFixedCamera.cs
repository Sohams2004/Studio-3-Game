using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorFixedCamera : MonoBehaviour
{
    public Camera playerCamera; 
    public Camera otherCamera; 
    public GameObject player; 

    private bool isSwitching = false; 

    void Start()
    { 
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.isTrigger = true; 
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

        yield return new WaitForSeconds(7f);

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

        
        isSwitching = false;
        
        GetComponent<Collider>().enabled = false;
    }
}
