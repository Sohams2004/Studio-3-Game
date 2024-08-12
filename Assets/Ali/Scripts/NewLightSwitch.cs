using TMPro;
using UnityEngine;

public class NewLightSwitch : MonoBehaviour
{
    public TextMeshProUGUI promptText; // TextMeshProUGUI to display the prompt
    public Animator switchAnimator; // Animator for the light switch
    public string animationTriggerName = "ToggleSwitch"; // Animation trigger name
    public Light roomLight; // Light to be controlled
    public AudioClip switchSound; // Sound effect for the switch
    private AudioSource audioSource;
    private bool playerInRange = false;
    private bool lightOn = false;
    public bool lightdone = false;
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
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                playerInRange = true;
                promptText.text = lightOn ? "Press E to Switch Off The Light" : "Press E to Switch On The Light";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    ToggleLight();
                }
            }
            else
            {
                playerInRange = false;
                promptText.text = string.Empty;
            }
        }
        else
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
        promptText.text = lightOn ? "Press E to Switch Off The Light" : "Press E to Switch On The Light";

        LightsTask.text = "Lights switched";
        LightsTask.color = Color.green;
        lightdone = true;
    }
}
