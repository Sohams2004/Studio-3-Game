using TMPro;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public TMP_Text promptText;
    public Animator objectAnimator;
    public AudioClip interactionSound;
    private AudioSource audioSource;
    [SerializeField] private bool playerInRange = false;
    [SerializeField] private bool hasInteracted = false;


    void Start()
    {

        promptText.text = string.Empty;
        audioSource = GetComponent<AudioSource>();

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
            objectAnimator.SetBool("Blindsup", false);
            objectAnimator.SetBool("Blindsdown", true);
            hasInteracted = false;

            audioSource.PlayOneShot(interactionSound);
        }
        /*    PlayBlindAnim();
        }

        void PlayBlindAnim()
        {
            if (objectPickUp.isBlinds)
            {
                promptText.text = "Press E to interact";

                if (Input.GetKeyDown(KeyCode.E) && !objectPickUp.isBlindsOpen)
                {
                    objectAnimator.SetBool("Blindsup", true);
                    objectAnimator.SetBool("Blindsdown", false);
                    hasInteracted = true;
                    audioSource.PlayOneShot(interactionSound);
                }  
            }

            else if (!objectPickUp.isBlinds)
            {
                promptText.text = string.Empty;

                if (Input.GetKeyDown(KeyCode.E) && objectPickUp.isBlindsOpen)
                {
                    objectAnimator.SetBool("Blindsdown", true);
                    objectAnimator.SetBool("Blindsup", false);
                    hasInteracted = false;

                    audioSource.PlayOneShot(interactionSound);
                }
            }*/
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
