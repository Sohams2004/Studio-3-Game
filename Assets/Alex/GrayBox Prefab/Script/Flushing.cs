using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Flushing : MonoBehaviour
{
    public TMP_Text promptText;
    [SerializeField] AudioSource audioSource;
    [SerializeField] DamageScript damageScript;

    private async void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))

        {
            promptText.text = "Press LeftClick to Flush";
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {

                audioSource.Play();
                await Task.Delay(100);
                damageScript.ThirstReduced(20);
                damageScript.HungerReduced(30);



            }
        }
    }
    private async void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))

        {
            promptText.text = "Press LeftClick to Flush";
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                audioSource.Play();
                await Task.Delay(100);
                damageScript.ThirstReduced(20);
                damageScript.HungerReduced(30);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        promptText.text = string.Empty;
    }
}
