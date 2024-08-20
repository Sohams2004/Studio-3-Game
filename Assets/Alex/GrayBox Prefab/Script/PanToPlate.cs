using System.Collections;
using UnityEngine;

public class PanTOPlate : MonoBehaviour
{
    public GameObject resultObjectPrefab;
    public Transform spawnPoint;
    public AudioClip interactionSound;
    public Animator blenderAnimator;
    [SerializeField] GameObject pan;
    private GameObject placedObject;
    [SerializeField] FriedEgg friedEgg;
    [SerializeField] GameObject parent;
    private bool isObjectPlaced = false;

    private AudioSource audioSource;

    private void Start()
    {
        pan.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        if (blenderAnimator == null)
        {
            Debug.Log("FryingPan Animator is not assigned!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isObjectPlaced && other.CompareTag("Frying Pan") && friedEgg.withEgg)
        {
            placedObject = other.gameObject;

            isObjectPlaced = true;
            pan.SetActive(true);

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

    public IEnumerator WaitAndSpawnObject(GameObject placedObject)
    {
        yield return new WaitForSeconds(1f);


        GameObject resultObject = Instantiate(resultObjectPrefab, spawnPoint.position, spawnPoint.rotation);
        resultObject.transform.parent = parent.transform;


        Destroy(placedObject);


        isObjectPlaced = false;
    }
}
