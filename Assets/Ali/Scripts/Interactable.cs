using UnityEngine;
using TMPro;
using System.Collections;

public class Interactable : MonoBehaviour
{
    public TextMeshProUGUI promptText; // TextMeshProUGUI to display the prompt
    public string promptMessage = "Press E to interact"; // Customizable prompt message
    public Animator objectAnimator; // Animator for the object
    public string animationTriggerName = "Interact"; // Customizable animation trigger name
    public AudioClip interactionSound; // Sound effect to play after delay
    private AudioSource audioSource;
    private bool playerInRange = false;
    private bool hasInteracted = false;

    void Start()
    {
        promptText.enabled = false; // Hide the text initially
        promptText.text = promptMessage; // Set the prompt message
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E) && !hasInteracted)
        {
            objectAnimator.SetTrigger(animationTriggerName);
            hasInteracted = true;
            promptText.enabled = false; // Hide the text after interaction
            StartCoroutine(PlaySoundAfterDelay(2.0f));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasInteracted)
        {
            playerInRange = true;
            promptText.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            promptText.enabled = false;
        }
    }

    IEnumerator PlaySoundAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        audioSource.PlayOneShot(interactionSound);
    }
}
