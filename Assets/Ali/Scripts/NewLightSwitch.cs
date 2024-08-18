using TMPro;
using UnityEngine;

public class NewLightSwitch : MonoBehaviour
{
    
    public Animator switchAnimator; 
    public string animationTriggerName = "ToggleSwitch"; 
    public Light roomLight; 
    public AudioClip switchSound; 
    private AudioSource audioSource;
    private bool playerInRange = false;
    private bool lightOn = false;
    public bool lightdone = false;
    public TextMeshProUGUI LightsTask;

    void Start()
    {
        /* promptText.text = string.Empty;*/

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
                /*  promptText.text = lightOn ? "Press E to Switch Off The Light" : "Press E to Switch On The Light";*/

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    ToggleLight();
                }
            }
            else
            {
                playerInRange = false;
                /*  promptText.text = string.Empty;*/
            }
        }
        else
        {
            playerInRange = false;
            /*   promptText.text = string.Empty;*/
        }
    }

    void ToggleLight()
    {
        lightOn = !lightOn;
        roomLight.enabled = lightOn;
        switchAnimator.SetTrigger(animationTriggerName);
        audioSource.PlayOneShot(switchSound);
        /* promptText.text = lightOn ? "Press E to Switch Off The Light" : "Press E to Switch On The Light";*/

        LightsTask.text = "Lights switched";
        LightsTask.color = Color.green;
        lightdone = true;
    }
}
