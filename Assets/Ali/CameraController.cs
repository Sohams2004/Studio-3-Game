using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera WakeUpCamera;
    public Camera playerCamera;  

    void Start()
    {
        
        WakeUpCamera.gameObject.SetActive(true);
        playerCamera.gameObject.SetActive(false);
    }

    public void SwitchToPlayerCamera()
    {
        
        WakeUpCamera.gameObject.SetActive(false);
        playerCamera.gameObject.SetActive(true);
    }
}
