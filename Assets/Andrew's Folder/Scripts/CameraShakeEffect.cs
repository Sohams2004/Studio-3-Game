using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraShakeEffect : MonoBehaviour
{
    public Slider hungerSlider;
    public Slider thirstSlider;
    public Camera mainCamera;
    public Transform player;
    public Movement playerMovement;

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

        if (player != null)
        {
            playerMovement = player.GetComponent<Movement>();
        }
    }

    void Update()
    {
        if (hungerSlider != null && thirstSlider != null && mainCamera != null && player != null)
        {
            float hungerValue = hungerSlider.value;
            float thirstValue = thirstSlider.value;

            if (hungerValue > 5600f || thirstValue > 5600f)
            {
                if (!isShaking)
                {
                    StartCoroutine(ShakeCamera());
                }

                if (playerMovement != null)
                {
                    playerMovement.movementSpeed = 1f;
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

                if (playerMovement != null)
                {
                    playerMovement.movementSpeed = 2f;
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