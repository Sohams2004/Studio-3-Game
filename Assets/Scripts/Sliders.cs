using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sliders : MonoBehaviour
{
    //[SerializeField] Slider MouseSenseslider;

    FPSCamera fpsCamera;

    public float MaxMouseSense;


    private void Start()
    {
        //MouseSenseslider.onValueChanged.AddListener(OnSliderChange);

        fpsCamera = FindObjectOfType<FPSCamera>();
    }

    public void OnSliderChange(float value)
    {
        fpsCamera.mouseSense = value * MaxMouseSense;
    }
}
