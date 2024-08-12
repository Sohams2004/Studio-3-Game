using System.Threading.Tasks;
using UnityEngine;

public class DoctorTalk : MonoBehaviour
{
    [SerializeField] AudioSource doctorTalk;
    private async void Start()
    {
        await Task.Delay(4000);
        doctorTalk.Play();

    }

}
