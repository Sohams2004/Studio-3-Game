using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarLogic : MonoBehaviour
{

    public Slider slider;

    public void SetMaxValue(float fill)
    {
        slider.maxValue = fill;
        slider.value = fill;
    }

    public void SetValue(float fill)
    {
        slider.value = fill;
    }

}
