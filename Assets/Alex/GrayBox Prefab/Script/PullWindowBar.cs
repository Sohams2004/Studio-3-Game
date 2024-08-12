using System.Threading.Tasks;
using UnityEngine;

public class PullWindowBar : MonoBehaviour
{
    [SerializeField] AudioSource blind;
    [SerializeField] Animator window;
    [SerializeField] AudioSource footStep;
    [SerializeField] AudioSource doctorTalk;
    private async void Start()
    {
        footStep.Play();
        await Task.Delay(4000);
        footStep.Stop();
        window.Play("Open Door Window");
        blind.Play();
        await Task.Delay(500);
        doctorTalk.Play();
        await Task.Delay(4000);
        window.Play("Close Door Window");
        blind.Play();
    }

}
