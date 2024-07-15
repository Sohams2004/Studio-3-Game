using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListActivator : MonoBehaviour
{
    public GameObject targetObject;  // The object to activate/deactivate

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Check if the player entered the trigger
        {
            targetObject.SetActive(true);  // Activate the target object
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))  // Check if the player exited the trigger
        {
            targetObject.SetActive(false);  // Deactivate the target object
        }
    }
}
