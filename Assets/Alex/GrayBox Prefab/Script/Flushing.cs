using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Flushing : MonoBehaviour
{
    public TMP_Text promptText;
    public Animator objectAnimator;
    [SerializeField] AudioSource audioSource;
    [SerializeField] DamageScript damageScript;

    private async void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))

        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                objectAnimator.SetBool("Flush", true);
                audioSource.Play();
                await Task.Delay(100);
                objectAnimator.SetBool("Flush", false);
                damageScript.HydrasionReduced(20);
                damageScript.HungerReduced(30);



            }
        }
    }
    private async void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))

        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                objectAnimator.SetBool("Flush", true);
                audioSource.Play();
                await Task.Delay(100);
                objectAnimator.SetBool("Flush", false);
                damageScript.HydrasionReduced(20);
                damageScript.HungerReduced(30);
            }
        }
    }
}
