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
            anim.SetBool("DoorSlam", true);
            slam.Play();
            await Task.Delay(100);
            anim.SetBool("DoorSlam", false);
            Destroy(gameObject);

        }
    }
}
