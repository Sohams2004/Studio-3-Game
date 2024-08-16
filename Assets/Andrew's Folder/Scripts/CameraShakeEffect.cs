using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class CameraShakeEffect : MonoBehaviour
{
    public Slider hungerSlider;
    public Camera mainCamera;
    public Transform player;
    public Movement playerMovement;
    [SerializeField] AntipsychoticsDrug antipsychoticsDrug;
    private Vector3 originalCameraOffset;
    private float shakeMagnitude = 0.1f;
    private float shakeDuration = 0.1f;
    private bool isShaking = false;
    private Coroutine shakeCoroutine;

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

    async void Update()
    {
        if (hungerSlider != null && mainCamera != null && player != null)
        {
            float hungerValue = hungerSlider.value;

            if (hungerValue < 500)
            {
                if (!isShaking && antipsychoticsDrug.medwithnofood == true)
                {
                    shakeCoroutine = StartCoroutine(ShakeCamera());
                    await Task.Delay(5000);
                }


            }
            else if (hungerValue > 500)
            {
                if (isShaking)
                {
                    StopCoroutine(shakeCoroutine);
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