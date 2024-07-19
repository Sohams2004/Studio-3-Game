using UnityEngine;
using UnityEngine.UI;

public class SanityDrainOnSight : MonoBehaviour
{
    public DamageScript damageScript;
    public string targetTag = "Hallucination";
    public float increasedSanityDecreaseRate = 100f;
    public Camera mainCamera;
    public float detectionRange = 100f;
    public Slider sanitySlider;

    private float originalSanityDecreaseRate;

    void Start()
    {
        if (damageScript == null)
        {
            Debug.LogError("DamageScript is not assigned.");
            return;
        }

        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        if (sanitySlider == null)
        {
            Debug.LogError("Sanity Slider is not assigned.");
            return;
        }

        originalSanityDecreaseRate = damageScript.sanityDecreaseRate;
    }

    void Update()
    {
        if (IsTargetInView())
        {
            damageScript.sanityDecreaseRate = increasedSanityDecreaseRate;
        }
        else
        {
            damageScript.sanityDecreaseRate = originalSanityDecreaseRate;
        }

        sanitySlider.value = damageScript.sanity;
    }

    bool IsTargetInView()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);
        foreach (GameObject target in targets)
        {
            Vector3 screenPoint = mainCamera.WorldToViewportPoint(target.transform.position);
            bool isInView = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

            if (isInView)
            {
                Ray ray = mainCamera.ScreenPointToRay(mainCamera.WorldToScreenPoint(target.transform.position));
                if (Physics.Raycast(ray, out RaycastHit hit, detectionRange))
                {
                    if (hit.collider.gameObject.CompareTag(targetTag))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}