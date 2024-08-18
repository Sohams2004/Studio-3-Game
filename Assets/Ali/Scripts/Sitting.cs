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
    public TextMeshProUGUI pressEToSitUI; 
    public TextMeshProUGUI pressEToStandUI; 
    private bool isMainPlayerActive = true;
    private bool isInChairTrigger = false;

    void Start()
    {
        pressEToSitUI.gameObject.SetActive(false); 
        pressEToStandUI.gameObject.SetActive(false); 
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
        secondPlayerAnimator.Play("SitAnimation");  
        pressEToSitUI.gameObject.SetActive(false); 
        pressEToStandUI.gameObject.SetActive(true); 
        isMainPlayerActive = false;
    }

    void SwitchToMainPlayer()
    {
        secondPlayer.SetActive(false);
        mainPlayer.SetActive(true);
        secondPlayerCamera.enabled = false;
        Camera.main.enabled = true;
        pressEToStandUI.gameObject.SetActive(false); 
        pressEToSitUI.gameObject.SetActive(true); 
        isMainPlayerActive = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Chair"))
        {
            isInChairTrigger = true;
            if (isMainPlayerActive)
            {
                pressEToSitUI.gameObject.SetActive(true); 
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Chair"))
        {
            isInChairTrigger = false;
            pressEToSitUI.gameObject.SetActive(false); 
            pressEToStandUI.gameObject.SetActive(false); 
        }
    }
}
