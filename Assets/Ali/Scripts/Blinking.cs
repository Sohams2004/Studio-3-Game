using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinking : MonoBehaviour
{
     public Animator animator; // Reference to the Animator component
    public string parameterName; // The name of the parameter to trigger the animation
    public float delay = 5f; // Time in seconds before playing the animation (default to 5 seconds)

    void Start()
    {
        // Start the coroutine
        StartCoroutine(PlayAnimationAfterDelayCoroutine());
    }

    IEnumerator PlayAnimationAfterDelayCoroutine()
    {
        Debug.Log("Waiting for delay...");
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        Debug.Log("Triggering animation after delay...");
        // Trigger the animation using the parameter
        animator.SetTrigger(parameterName);
    }
}
