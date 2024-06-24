using TMPro;
using UnityEngine;

public class WhisperKnock : MonoBehaviour
{
    [SerializeField] AudioSource whisper;
    [SerializeField] AudioSource knock;
    [SerializeField] TMP_Text doortext;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            whisper.Play();
            doortext.text = "Parent Room";
            if (Input.GetKeyDown(KeyCode.E))
            {
                knock.Play();
                doortext.text = "Locked";
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                knock.Play();
                doortext.text = "Locked";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        doortext.text = string.Empty;
    }
}
