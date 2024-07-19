using UnityEngine;
using System.Collections;

public class HallucinationTrigger : MonoBehaviour
{
    public float disappearTime = 5.0f;

    public GameObject targetGameObject;

    private void Start()
    {
            targetGameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") && targetGameObject != null)
        {
            targetGameObject.SetActive(true);

            StartCoroutine(DisappearAfterTime());
        }
    }

    private IEnumerator DisappearAfterTime()
    {
        yield return new WaitForSeconds(disappearTime);

        if (targetGameObject != null)
        {
            targetGameObject.SetActive(false);
        }
    }
}