using UnityEngine;
using UnityEngine.UI;

public class EnvironmentChange : MonoBehaviour
{
    public Slider insanityBar;
    public float insanityThreshold = 0.3f;
    public Color normalColor = Color.white;
    public Color insaneColor = Color.red;
    public Material skyboxMaterial;

    void Start()
    {
        if (skyboxMaterial == null)
        {
            Debug.LogError("Skybox material is not assigned.");
            enabled = false;
            return;
        }

        if (insanityBar == null)
        {
            Debug.LogError("Insanity bar slider is not assigned.");
            enabled = false;
        }
    }

    void Update()
    {
        if (insanityBar == null) return;

        float insanityValue = insanityBar.value;

        if (insanityValue <= insanityThreshold)
        {
            float t = Mathf.InverseLerp(insanityThreshold, 0, insanityValue);
            RenderSettings.skybox.SetColor("_Tint", Color.Lerp(normalColor, insaneColor, t));
        }
        else
        {
            RenderSettings.skybox.SetColor("_Tint", normalColor);
        }
    }
}