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
    private Coroutine shakeCoroutine;
    private float originalMovementSpeed;

    void Start()
    {
        if (mainCamera != null && player != null)
        {
            originalCameraOffset = mainCamera.transform.position - player.position;
        }

        if (player != null)
        {
            playerMovement = player.GetComponent<Movement>();
            originalMovementSpeed = playerMovement.movementSpeed;
        }
    }

    void Update()
    {
        if (hungerSlider != null && thirstSlider != null && mainCamera != null && player != null)
        {
            float hungerValue = hungerSlider.value;
            float thirstValue = thirstSlider.value;

            if (hungerValue > 240f || thirstValue > 240f)
            {
                if (!isShaking)
                {
                    shakeCoroutine = StartCoroutine(ShakeCamera());
                }

                if (playerMovement != null)
                {
                    playerMovement.movementSpeed = 0.8f;
                }
            }
            else
            {
                if (isShaking)
                {
                    StopCoroutine(shakeCoroutine);
                    mainCamera.transform.position = player.position + originalCameraOffset;
                    isShaking = false;
                }

                if (playerMovement != null)
                {
                    playerMovement.movementSpeed = originalMovementSpeed;
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