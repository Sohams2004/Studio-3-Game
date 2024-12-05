using UnityEngine;

public class ListActivator : MonoBehaviour
{
    public GameObject targetObject;  // The object to activate/deactivate
    [SerializeField] GameObject panel;
    private void Start()
    {
        panel.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Check if the player entered the trigger
        {
            targetObject.SetActive(true);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))  // Check if the player exited the trigger
        {
            targetObject.SetActive(false);
            panel.SetActive(true);// Deactivate the target object
        }
    }
}
