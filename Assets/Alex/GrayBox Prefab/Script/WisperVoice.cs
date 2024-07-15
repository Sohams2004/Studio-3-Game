using UnityEngine;

public class WisperVoice : MonoBehaviour
{
    [SerializeField] GameObject closeWhisperer;
    private void Start()
    {
        closeWhisperer.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            closeWhisperer.SetActive(true);

        }


    }
}
