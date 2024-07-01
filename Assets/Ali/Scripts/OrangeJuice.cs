using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeJuice : MonoBehaviour
{
    public GameObject resultObjectPrefab; // Prefab of the result object to instantiate after a delay
    public Transform spawnPoint; // Spawn point for the result object
    public AudioClip interactionSound; // Sound to play during interaction
    public AnimationClip interactionAnimation; // Animation to play during interaction

    private GameObject placedObject; // Reference to the object currently placed on the trigger
    private bool isObjectPlaced = false;

    private AudioSource audioSource; // AudioSource component for playing sounds
    private Animator animator; // Animator component for playing animations

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get AudioSource component
        animator = GetComponent<Animator>(); // Get Animator component
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isObjectPlaced && other.CompareTag("Orange")) // Check if the object entering is the player's object
        {
            placedObject = other.gameObject; // Assign the placed object
            isObjectPlaced = true;

            // Play animation if animator and animation are assigned
            if (animator != null && interactionAnimation != null)
            {
                animator.Play(interactionAnimation.name);
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

        // Play additional sound or animation on the result object if needed

        // Clean up or reset as needed
        Destroy(placedObject); // Destroy the placed object
        isObjectPlaced = false;
    }
}
