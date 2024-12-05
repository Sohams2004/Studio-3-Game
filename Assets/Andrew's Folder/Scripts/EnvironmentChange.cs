using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class EnvironmentChange : MonoBehaviour
{
    public float intensity;
    PostProcessVolume _volume;
    Vignette _vignette;

    public Slider insanityBar;
    public float insanityThreshold = 0.3f;

    void Start()
    {
        _volume = GetComponent<PostProcessVolume>();

        _volume.profile.TryGetSettings<Vignette>(out _vignette);

        if (!_vignette)
        {
            Debug.Log("Vignette is empty");
        }
        else
        {
            _vignette.enabled.Override(false);
        }
    }

    void Update()
    {
        if (insanityBar == null) return;

        float insanityValue = insanityBar.value;

        while (insanityValue <= insanityThreshold)
        {
            StartCoroutine(PostProcessingEffect());
        }
    }
    private IEnumerator PostProcessingEffect()
    {
        intensity = 0;

        _vignette.enabled.Override(true);
        _vignette.intensity.Override(0);

        yield return new WaitForSeconds(0.4f);

        while (intensity > 0)
        {
            intensity += 0.01f;
            if (intensity < 0.4f) intensity = 0.4f;

            _vignette.intensity.Override(intensity);

            yield return new WaitForSeconds(0.1f);
        }

        _vignette.enabled.Override(false);
        yield break;
    }
}