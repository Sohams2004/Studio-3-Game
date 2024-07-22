using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraShakeEffect : MonoBehaviour
{
    public Slider hungerSlider;
    public Slider thirstSlider;
    public Camera mainCamera;
    public Transform player;

    private Vector3 originalCameraOffset;
    private float shakeMagnitude = 0.1f;
    private float shakeDuration = 0.1f;
    private bool isShaking = false;

    void Start()
    {
        if (mainCamera != null && player != null)
        {
            originalCameraOffset = mainCamera.transform.position - player.position;
        }
    }

    void Update()
    {
        if (hungerSlider != null && thirstSlider != null && mainCamera != null && player != null)
        {
            float hungerValue = hungerSlider.value / hungerSlider.maxValue;
            float thirstValue = thirstSlider.value / thirstSlider.maxValue;

            if (hungerValue > 0.9f || thirstValue > 0.9f)
            {
                if (!isShaking)
                {
                    StartCoroutine(ShakeCamera());
                }
            }
            else
            {
                if (isShaking)
                {
                    StopCoroutine(ShakeCamera());
                    mainCamera.transform.position = player.position + originalCameraOffset;
                    isShaking = false;
                }
            }
        }
    }

    private IEnumerator ShakeCamera()
    {
        isShaking = true;
        while (true)
        {
            Vector3 randomPoint = originalCameraOffset + Random.insideUnitSphere * shakeMagnitude;
            mainCamera.transform.position = player.position + new Vector3(randomPoint.x, originalCameraOffset.y, originalCameraOffset.z);
            yield return new WaitForSeconds(shakeDuration);
        }
    }
}
