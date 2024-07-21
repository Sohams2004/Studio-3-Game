using System.Collections;
using UnityEngine;

public class PanTOPlate : MonoBehaviour
{
    public GameObject resultObjectPrefab; // Prefab of the result object to instantiate after a delay
    public Transform spawnPoint;
    public Transform fryingpanPoint;// Spawn point for the result object
    public AudioClip interactionSound; // Sound to play during interaction
    public Animator blenderAnimator; // Animator component for the blender animations
    [SerializeField] GameObject pan;
    private GameObject placedObject;
    private GameObject placedObject2;
    // Reference to the object currently placed on the trigger
    [SerializeField] GameObject parent;
    [SerializeField] GameObject parent2;
    public GameObject fryingPanPrefab;
    private bool isObjectPlaced = false;

    private AudioSource audioSource; // AudioSource component for playing sounds

    private void Start()
    {
        pan.SetActive(false);
        audioSource = GetComponent<AudioSource>(); // Get AudioSource component

        // Ensure blenderAnimator is assigned
        if (blenderAnimator == null)
        {
            Debug.LogError("FryingPan Animator is not assigned!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isObjectPlaced && other.CompareTag("Frying Pan")) // Check if the object entering is the player's object
        {
            placedObject = other.gameObject;
            // Assign the placed object
            isObjectPlaced = true;

            // Play animation using Animator trigger
            if (blenderAnimator != null)
            {
                blenderAnimator.SetTrigger("Fry");
            }

            // Play sound if AudioSource and sound clip are assigned
            if (audioSource != null && interactionSound != null)
            {
                audioSource.PlayOneShot(interactionSound);
            }

            //Destroy(placedObject);

            // Start coroutine to wait and then spawn result object
            StartCoroutine(WaitAndSpawnObject(placedObject, placedObject2));
        }
    }

    public IEnumerator WaitAndSpawnObject(GameObject placedObject, GameObject placedObject2)
    {
        yield return new WaitForSeconds(2f); // Wait for 2 seconds

        // Instantiate the result object at the spawn point
        GameObject resultObject = Instantiate(resultObjectPrefab, spawnPoint.position, spawnPoint.rotation);
        resultObject.transform.parent = parent.transform;

        // Clean up or reset as needed
        Destroy(placedObject);
        pan.SetActive(true);
        pan.transform.parent = parent2.transform;
        // Destroy the placed object
        isObjectPlaced = false;
    }
}
