using System.Collections;
using UnityEngine;

public class FriedEgg : MonoBehaviour
{
    public GameObject resultObjectPrefab;
    public Transform spawnPoint;
    public AudioClip interactionSound;
    public Animator blenderAnimator;

    private GameObject placedObject;
    [SerializeField] GameObject parent;
    private bool isObjectPlaced = false;
    public bool withEgg = false;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (blenderAnimator == null)
        {
            Debug.LogError("FryingPan Animator is not assigned!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isObjectPlaced && other.CompareTag("Egg"))
        {
            placedObject = other.gameObject;
            isObjectPlaced = true;


            if (blenderAnimator != null)
            {
                blenderAnimator.SetTrigger("Fry");
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
        yield return new WaitForSeconds(2f);


        GameObject resultObject = Instantiate(resultObjectPrefab, spawnPoint.position, spawnPoint.rotation);
        resultObject.transform.parent = parent.transform;
        isObjectPlaced = false;
        withEgg = true;

        Destroy(placedObject);

    }
}
