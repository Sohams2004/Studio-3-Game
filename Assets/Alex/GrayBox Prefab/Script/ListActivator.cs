using UnityEngine;

public class ListActivator : MonoBehaviour
{
    public GameObject targetObject;
    public GameObject indicator;
    [SerializeField] bool isInside = false;
    [SerializeField] bool isActive = false;


    private void Start()
    {
        targetObject.SetActive(false);
        indicator.SetActive(false);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isActive && isInside)
        {
            targetObject.SetActive(true);

        }
        if (Input.GetKeyDown(KeyCode.E) && isActive && isInside)
        {
            targetObject.SetActive(false);

        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Check if the player entered the trigger
        {
            if (!isActive)
            {
                isInside = true;
            }
            else if (isActive)
            {
                isInside = true;
            }

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))  // Check if the player exited the trigger
        {
            isInside = false;
            /*targetObject.SetActive(false);*/
        }
    }
}
