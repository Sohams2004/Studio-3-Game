using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairColor : MonoBehaviour
{
    public Image crosshairImage; 
    public Color defaultColor = Color.red;
    public Color highlightColor = Color.green;
    public LayerMask targetLayerMask; 

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, targetLayerMask))
        {
            crosshairImage.color = highlightColor; 
        }
        else
        {
            crosshairImage.color = defaultColor; 
        }
    }
}
