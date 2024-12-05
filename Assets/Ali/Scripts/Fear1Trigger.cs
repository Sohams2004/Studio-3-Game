using System.Collections;
using UnityEngine;

public class Fear1Trigger : MonoBehaviour
{
    public AudioSource audioSource; // The AudioSource component with the audio clip
    public GameObject humanPrefab; // The human prefab to instantiate
    public Transform spawnPoint; // The point where the human will be spawned

    private bool hasTriggered = false; // To ensure the action happens only once
    private GameObject instantiatedHuman; // To keep track of the instantiated human

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
}
