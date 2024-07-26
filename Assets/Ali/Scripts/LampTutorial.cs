using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampTutorial : MonoBehaviour
{
     public GameObject lamp; // Assign the lamp object in the Inspector
    public GameObject lightSource; // Assign the specific light source to activate
    public GameObject lightText; // Assign the 3D Text object in the Inspector
    public KeyCode lightKey = KeyCode.E;

    private bool isLightOn = false;

    void Update()
    {
        // Check if the player is looking at the lamp object
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        {
            if (hit.collider.CompareTag("Lamp"))
            {
                lightText.SetActive(true);

                // Check if the light key is pressed
                if (Input.GetKeyDown(lightKey))
                {
                    isLightOn = !isLightOn; // Toggle the light state
                    lightSource.SetActive(isLightOn);
                }
            }
            else
            {
                lightText.SetActive(false);
            }
        }
        else
        {
            lightText.SetActive(false);
        }
    }
}
