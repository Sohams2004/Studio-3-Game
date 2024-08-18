using System.Collections;
using UnityEngine;

public class Toaster : MonoBehaviour
{
    public GameObject resultObjectPrefab; 
    public Transform spawnPoint; 
    public AudioClip interactionSound; 

    private GameObject placedObject; 
    private bool isObjectPlaced = false;

    private AudioSource audioSource; 

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); 

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isObjectPlaced && other.CompareTag("Toast")) 
        {
            placedObject = other.gameObject; 
            isObjectPlaced = true;



            if (audioSource != null && interactionSound != null)
            {
                audioSource.PlayOneShot(interactionSound);
            }

            
            StartCoroutine(WaitAndSpawnObject(placedObject));
        }
    }

    private IEnumerator WaitAndSpawnObject(GameObject placedObject)
    {
        Destroy(placedObject);
        yield return new WaitForSeconds(1f); 

       
        GameObject resultObject = Instantiate(resultObjectPrefab, spawnPoint.position, spawnPoint.rotation);

        isObjectPlaced = false;
    }
}
