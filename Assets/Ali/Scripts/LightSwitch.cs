using TMPro;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public TextMeshProUGUI promptText; // TextMeshProUGUI to display the prompt

    public Animator switchAnimator; // Animator for the light switch
    public string animationTriggerName = "ToggleSwitch"; // Animation trigger name
    public Light roomLight; // Light to be controlled
    public AudioClip switchSound; // Sound effect for the switch
    private AudioSource audioSource;
    private bool playerInRange = false;
    private bool lightOn = false;

    void Start()
    {
        promptText.text = string.Empty;

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
            promptText.text = "Press E to Switch On The Light";
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            promptText.text = "Press E to Switch On The Light";
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            promptText.text = string.Empty;
        }
    }

    void ToggleLight()
    {
        lightOn = !lightOn;
        roomLight.enabled = lightOn;
        switchAnimator.SetTrigger(animationTriggerName);
        audioSource.PlayOneShot(switchSound);
        promptText.text = "Press E to Switch Off The Light";
    }
}
