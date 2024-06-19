using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurtainTrigger : MonoBehaviour
{
   public TextMeshProUGUI promptText; // TextMeshProUGUI to display the prompt
    public Animator curtainAnimator; // Animator for the curtains
    private bool playerInRange = false;
    private bool curtainsOpened = false;

    void Start()
    {
        promptText.enabled = false; // Hide the text initially
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E) && !curtainsOpened)
        {
            curtainAnimator.SetTrigger("OpenCurtains");
            curtainsOpened = true;
            promptText.enabled = false; // Hide the text after opening the curtains
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !curtainsOpened)
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
}
