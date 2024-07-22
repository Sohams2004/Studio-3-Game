using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraShut : MonoBehaviour
{
     public Animator animator; // Reference to the Animator component
    public string animationTriggerName = "CameraShut"; // Name of the animation trigger
    public float delayBeforeAnimation; // Time delay before the animation starts
    public float animationDuration; // Duration of the animation
    public string nextSceneName; // Name of the next scene to load

    void Start()
    {
        // Start the animation after the specified delay
        Invoke("StartAnimation", delayBeforeAnimation);
    }

    void StartAnimation()
    {
        // Trigger the animation
        animator.SetTrigger(animationTriggerName);

        // Start a coroutine to load the next scene after the specified duration
        StartCoroutine(LoadNextSceneAfterAnimation());
    }

    IEnumerator LoadNextSceneAfterAnimation()
    {
        // Wait for the specified animation duration
        yield return new WaitForSeconds(animationDuration);

        // Load the next scene
        SceneManager.LoadScene(nextSceneName);
    }
}
