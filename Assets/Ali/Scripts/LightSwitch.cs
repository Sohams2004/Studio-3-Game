using UnityEngine;
using TMPro;

public class LightSwitch : MonoBehaviour
{
    public TextMeshProUGUI promptText; // TextMeshProUGUI to display the prompt
    public string promptMessage = "Press E to switch light"; // Customizable prompt message
    public Animator switchAnimator; // Animator for the light switch
    public string animationTriggerName = "ToggleSwitch"; // Animation trigger name
    public Light roomLight; // Light to be controlled
    public AudioClip switchSound; // Sound effect for the switch
    private AudioSource audioSource;
    private bool playerInRange = false;
    private bool lightOn = false;

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
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            ToggleLight();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
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

    void ToggleLight()
    {
        lightOn = !lightOn;
        roomLight.enabled = lightOn;
        switchAnimator.SetTrigger(animationTriggerName);
        audioSource.PlayOneShot(switchSound);
        promptText.enabled = false; // Hide the text after interaction
    }
}
