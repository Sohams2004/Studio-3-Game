using UnityEngine;

public class DoorSlam : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] AudioSource slam;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("DoorSlam", true);
            slam.Play();
            Destroy(gameObject);
        }
    }
}
