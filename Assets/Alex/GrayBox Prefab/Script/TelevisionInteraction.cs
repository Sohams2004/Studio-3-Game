using TMPro;
using UnityEngine;

public class TelevisionInteraction : MonoBehaviour
{
    [SerializeField] GameObject screen;
    public LightmapData[] lightmapsOn;
    public LightmapData[] lightmapsOff;

    [SerializeField] AudioSource voice;
    [SerializeField] AudioSource staticnoice;
    [SerializeField] bool hasInteracted = false;
    [SerializeField] bool playerInRange = false;
    [SerializeField] TMP_Text tvtext;

    private void Start()
    {
        screen.SetActive(false);
        LightmapSettings.lightmaps = lightmapsOff;
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E) && !hasInteracted)
        {
            screen.SetActive(true);
            staticnoice.Play();
            voice.Play();
            LightmapSettings.lightmaps = lightmapsOn;
            hasInteracted = true;
        }

        else if (playerInRange && Input.GetKeyDown(KeyCode.E) && hasInteracted)
        {
            screen.SetActive(false);
            staticnoice.Stop();
            voice.Stop();
            LightmapSettings.lightmaps = lightmapsOff;
            hasInteracted = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            if (!hasInteracted)
            {
                tvtext.text = "Press E to interact";
                playerInRange = true;
            }

            if (hasInteracted)
            {
                tvtext.text = "Press E to interact";
                playerInRange = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!hasInteracted)
            {
                tvtext.text = "Press E to interact";
                playerInRange = true;
            }

            if (hasInteracted)
            {
                tvtext.text = "Press E to interact";
                playerInRange = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        tvtext.text = string.Empty;
    }
}
