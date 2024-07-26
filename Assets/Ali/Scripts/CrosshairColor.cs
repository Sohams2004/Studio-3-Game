using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairColor : MonoBehaviour
{
    public Image crosshairImage; // Assign the crosshair Image in the Inspector
    public Color defaultColor = Color.red;
    public Color highlightColor = Color.green;
    public LayerMask targetLayerMask; // Assign the LayerMask in the Inspector

    void Update()
    {
        // Check if the player is looking at an object with the specified layer
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, targetLayerMask))
        {
            crosshairImage.color = highlightColor; // Change crosshair color to green
        }
        else
        {
            crosshairImage.color = defaultColor; // Change crosshair color to red
        }
    }
}
