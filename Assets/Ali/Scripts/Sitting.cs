using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sitting : MonoBehaviour
{
     public GameObject mainPlayer;
    public GameObject secondPlayer;
    public Camera secondPlayerCamera;
    public Animator secondPlayerAnimator;
    public TextMeshProUGUI pressEToSitUI; // UI element to show "Press E to Sit"
    public TextMeshProUGUI pressEToStandUI; // UI element to show "Press E to Stand"
    private bool isMainPlayerActive = true;
    private bool isInChairTrigger = false;

    void Start()
    {
        pressEToSitUI.gameObject.SetActive(false); // Hide the "Press E to Sit" UI at start
        pressEToStandUI.gameObject.SetActive(false); // Hide the "Press E to Stand" UI at start
    }

    void Update()
    {
        if (isInChairTrigger && Input.GetKeyDown(KeyCode.E))
        {
            if (isMainPlayerActive)
            {
                SwitchToSecondPlayer();
            }
            else
            {
                SwitchToMainPlayer();
            }
        }
    }

    void SwitchToSecondPlayer()
    {
        mainPlayer.SetActive(false);
        secondPlayer.SetActive(true);
        secondPlayerCamera.enabled = true;
        Camera.main.enabled = false;
        secondPlayerAnimator.Play("SitAnimation");  // Replace with your sitting animation name
        pressEToSitUI.gameObject.SetActive(false); // Hide the "Press E to Sit" UI
        pressEToStandUI.gameObject.SetActive(true); // Show the "Press E to Stand" UI
        isMainPlayerActive = false;
    }

    void SwitchToMainPlayer()
    {
        secondPlayer.SetActive(false);
        mainPlayer.SetActive(true);
        secondPlayerCamera.enabled = false;
        Camera.main.enabled = true;
        pressEToStandUI.gameObject.SetActive(false); // Hide the "Press E to Stand" UI
        pressEToSitUI.gameObject.SetActive(true); // Show the "Press E to Sit" UI
        isMainPlayerActive = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Chair"))
        {
            isInChairTrigger = true;
            if (isMainPlayerActive)
            {
                pressEToSitUI.gameObject.SetActive(true); // Show the "Press E to Sit" UI
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Chair"))
        {
            isInChairTrigger = false;
            pressEToSitUI.gameObject.SetActive(false); // Hide the "Press E to Sit" UI
            pressEToStandUI.gameObject.SetActive(false); // Hide the "Press E to Stand" UI
        }
    }
}
