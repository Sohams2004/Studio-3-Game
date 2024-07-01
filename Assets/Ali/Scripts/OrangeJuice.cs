using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeJuice : MonoBehaviour
{
     public GameObject resultObjectPrefab; // Prefab of the result object to instantiate after a delay
    public Transform spawnPoint; // Spawn point for the result object
    public AudioClip interactionSound; // Sound to play during interaction
    public Animator blenderAnimator; // Animator component for the blender animations

    private GameObject placedObject; // Reference to the object currently placed on the trigger
    private bool isObjectPlaced = false;

    private AudioSource audioSource; // AudioSource component for playing sounds

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get AudioSource component
        
        // Ensure blenderAnimator is assigned
        if (blenderAnimator == null)
        {
            Debug.LogError("Blender Animator is not assigned!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isObjectPlaced && other.CompareTag("Orange")) // Check if the object entering is the player's object
        {
            placedObject = other.gameObject; // Assign the placed object
            isObjectPlaced = true;

            // Play animation using Animator trigger
            if (blenderAnimator != null)
            {
                blenderAnimator.SetTrigger("Blend");
            }

            // Play sound if AudioSource and sound clip are assigned
            if (audioSource != null && interactionSound != null)
            {
                audioSource.PlayOneShot(interactionSound);
            }

            // Start coroutine to wait and then spawn result object
            StartCoroutine(WaitAndSpawnObject(placedObject));
        }
    }

    private IEnumerator WaitAndSpawnObject(GameObject placedObject)
    {
        yield return new WaitForSeconds(2f); // Wait for 2 seconds

        // Instantiate the result object at the spawn point
        GameObject resultObject = Instantiate(resultObjectPrefab, spawnPoint.position, spawnPoint.rotation);

        // Clean up or reset as needed
        Destroy(placedObject); // Destroy the placed object
        isObjectPlaced = false;
    }
}
