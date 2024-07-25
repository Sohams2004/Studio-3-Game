using System.Threading.Tasks;
using UnityEngine;

public class DoorSlam : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] AudioSource slam;
    private async void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.Play("DoorSlam");
            slam.Play();
            await Task.Delay(100);

            Destroy(gameObject);

        }
    }
}
