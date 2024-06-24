using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityBar : MonoBehaviour
{

    public Slider slider;

    public void SetMaxValue(float sanity)
    {
        slider.maxValue = sanity;
        slider.value = sanity;
    }

    public void SetValue(float sanity)
    {
        slider.value = sanity;
    }

}
