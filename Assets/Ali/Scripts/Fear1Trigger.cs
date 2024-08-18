using System.Collections;
using UnityEngine;

public class Fear1Trigger : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject humanPrefab;
    public Transform spawnPoint;

    private bool hasTriggered = false;
    private GameObject instantiatedHuman;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            InstantiateHuman();
            PlayAudioAndDestroyHuman();
        }
    }

    private void InstantiateHuman()
    {
        instantiatedHuman = Instantiate(humanPrefab, spawnPoint.position, spawnPoint.rotation);

        
        StartCoroutine(FadeOutHuman(0.01f, 7f)); 
    }

    private void PlayAudioAndDestroyHuman()
    {
        audioSource.Play();
        StartCoroutine(WaitAndDestroy(audioSource.clip.length));
    }

    private IEnumerator WaitAndDestroy(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(instantiatedHuman);
    }

    private IEnumerator FadeOutHuman(float delay, float fadeDuration)
    {
        yield return new WaitForSeconds(delay); 

        float rate = 1.0f / fadeDuration;
        float progress = 0.0f;

        Renderer[] renderers = instantiatedHuman.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            foreach (Material mat in renderer.materials)
            {
                // Ensure the material is in Transparent mode
                mat.SetFloat("_Mode", 2); // Set material mode to Transparent
                mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                mat.SetInt("_ZWrite", 0);
                mat.DisableKeyword("_ALPHATEST_ON");
                mat.EnableKeyword("_ALPHABLEND_ON");
                mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                mat.renderQueue = 5000;
            }
        }

       
        while (progress < 1.0f)
        {
            foreach (Renderer renderer in renderers)
            {
                foreach (Material mat in renderer.materials)
                {
                    Color color = mat.color;
                    color.a = Mathf.Lerp(1.0f, 0.0f, progress);
                    mat.color = color;
                }
            }

            progress += rate * Time.deltaTime;
            yield return null;
        }

        foreach (Renderer renderer in renderers)
        {
            foreach (Material mat in renderer.materials)
            {
                Color color = mat.color;
                color.a = 0.0f;
                mat.color = color;
            }
        }
    }
}
