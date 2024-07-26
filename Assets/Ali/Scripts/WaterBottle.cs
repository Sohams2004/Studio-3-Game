using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaterBottle : MonoBehaviour
{
   public GameObject drinkText; // Assign the 3D Text object in the Inspector
    public KeyCode drinkKey = KeyCode.F;

    private GameObject currentBottle = null;

    void Update()
    {
        // Check if the player is looking at an object with the tag "Bottle"
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        {
            if (hit.collider.CompareTag("Bottle"))
            {
                currentBottle = hit.collider.gameObject;
                drinkText.SetActive(true);
                drinkText.transform.position = currentBottle.transform.position + Vector3.up; // Adjust position above the bottle
            }
            else
            {
                currentBottle = null;
                drinkText.SetActive(false);
            }
        }
        else
        {
            currentBottle = null;
            drinkText.SetActive(false);
        }

        // Check if the drink key is pressed
        if (currentBottle != null && Input.GetKeyDown(drinkKey))
        {
            Destroy(currentBottle);
            currentBottle = null;
            drinkText.SetActive(false);
        }
    }
}
