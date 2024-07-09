using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepTrigger : MonoBehaviour
{
    public Camera sleepingCamera;   // Assign your sleeping camera in the Inspector
    public Animator cameraAnimator; // Assign the Animator controlling the sleeping camera animation

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Disable player movement or any other relevant gameplay mechanics here if needed

            // Trigger the sleeping animation
            cameraAnimator.SetTrigger("SleepTrigger");

            // Activate the sleeping camera
            sleepingCamera.gameObject.SetActive(true);
        }
    }
}
