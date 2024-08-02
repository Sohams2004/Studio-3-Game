using System.Collections;
using UnityEngine;

public class CameraShut : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component
    public string animationTriggerName = "CameraShut"; // Name of the animation trigger
    public float delayBeforeAnimation; // Time delay before the animation starts
    public float animationDuration; // Duration of the animation
    public string nextSceneName; // Name of the next scene to load

    private bool animationStarted = false; // Flag to check if the animation has already started
    [SerializeField] LoadingScene scene;

    void Start()
    {
        // Start the animation after the specified delay
        Invoke("StartAnimation", delayBeforeAnimation);
        scene.LoadingScreen.SetActive(false);
    }

    void Update()
    {
        // Check if the "C" key is pressed
        if (Input.GetKeyDown(KeyCode.C) && !animationStarted)
        {
            SkipCutscene();
        }
    }

    void StartAnimation()
    {
        // Trigger the animation
        animator.SetTrigger(animationTriggerName);
        animationStarted = true;

        // Start a coroutine to load the next scene after the specified duration
        StartCoroutine(LoadNextSceneAfterAnimation());
    }

    void SkipCutscene()
    {
        // Trigger the animation immediately
        animator.SetTrigger(animationTriggerName);
        animationStarted = true;

        // Start a coroutine to load the next scene immediately after the animation
        StartCoroutine(LoadNextSceneAfterAnimation());
    }

    IEnumerator LoadNextSceneAfterAnimation()
    {
        // Wait for the specified animation duration
        yield return new WaitForSeconds(animationDuration);
        scene.LoadingScreen.SetActive(true);
        scene.LoadScene(2);
    }


}
