using TMPro;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public TMP_Text promptText; // TextMeshProUGUI to display the prompt
    public string promptMessage = "Press E to interact"; // Customizable prompt message
    public Animator objectAnimator; // Animator for the object
    public string animationTriggerName = "Interact"; // Customizable animation trigger name
    public AudioClip interactionSound; // Sound effect to play after delay
    private AudioSource audioSource;
    private bool playerInRange = false;
    private bool hasInteracted = false;

    void Start()
    {
        promptText.text = string.Empty;
        /* promptText.text = promptMessage; // Set the prompt message*/
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
            objectAnimator.SetBool("Blindsup", true);
            objectAnimator.SetBool("Blindsdown", false);
            hasInteracted = true;
            audioSource.PlayOneShot(interactionSound);
        }
        else if (playerInRange && Input.GetKeyDown(KeyCode.E) && hasInteracted)
        {
            objectAnimator.SetBool("Blindsdown", true);
            objectAnimator.SetBool("Blindsup", false);
            hasInteracted = false;

            audioSource.PlayOneShot(interactionSound);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!hasInteracted)
            {
                playerInRange = true;
                promptText.text = "Press E to interact";
            }
            else if (hasInteracted)
            {
                playerInRange = true;
                promptText.text = "Press E to interact";
            }


        }
    }
    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            if (!hasInteracted)
            {
                playerInRange = true;
                promptText.text = "Press E to interact";
            }
            else if (hasInteracted)
            {
                playerInRange = true;
                promptText.text = "Press E to interact";
            }


        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            promptText.text = string.Empty;
            playerInRange = false;

        }
    }


}
