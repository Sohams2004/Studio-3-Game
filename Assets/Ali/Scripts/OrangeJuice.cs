using System.Collections;
using UnityEngine;

public class OrangeJuice : MonoBehaviour
{
    public GameObject resultObjectPrefab; 
    public Transform spawnPoint; 
    public AudioClip interactionSound; 
    public Animator blenderAnimator; 

    private GameObject placedObject; 
    private bool isObjectPlaced = false;

    private AudioSource audioSource; 

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); 

        if (blenderAnimator == null)
        {
            Debug.LogError("Blender Animator is not assigned!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isObjectPlaced && other.CompareTag("Orange")) 
        {
            placedObject = other.gameObject; 
            isObjectPlaced = true;

            if (blenderAnimator != null)
            {
                blenderAnimator.SetTrigger("Blend");
            }

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
        yield return new WaitForSeconds(2f); 

        
        GameObject resultObject = Instantiate(resultObjectPrefab, spawnPoint.position, spawnPoint.rotation);

        
        isObjectPlaced = false;
    }
}
