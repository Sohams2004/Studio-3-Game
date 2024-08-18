using TMPro;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public TextMeshProUGUI promptText; 

    public Animator switchAnimator; 
    public string animationTriggerName = "ToggleSwitch"; 
    public Light roomLight; 
    public AudioClip switchSound; 
    private AudioSource audioSource;
    private bool playerInRange = false;
    private bool lightOn = false;

    public TextMeshProUGUI LightsTask;

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

        LightsTask.text = "Lights switched";
        LightsTask.color = Color.green;
    }
}
