using TMPro;
using UnityEngine;

public class ParentRoomKey : MonoBehaviour
{
    public TMP_Text promptText;
    private AudioSource audioSource;
    [SerializeField] GameObject keyCollected;
    [SerializeField] GameObject key;
    public bool pickedkey = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            promptText.text = "Press E to interact";
            if (Input.GetKeyDown(KeyCode.E))
            {
                promptText.text = string.Empty;
                key.SetActive(false);
                keyCollected.SetActive(true);
                audioSource.Play();
                pickedkey = true;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        promptText.text = "Press E to interact";
        if (Input.GetKeyDown(KeyCode.E))
        {
            promptText.text = string.Empty;
            key.SetActive(false);
            keyCollected.SetActive(true);
            audioSource.Play();
            pickedkey = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        promptText.text = string.Empty;
    }
}
