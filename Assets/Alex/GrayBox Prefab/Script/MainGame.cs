using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGame : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;
    [SerializeField] Animator tigerAnimator;


    async void Update()
    {
        if (player != null)
        {
            await Task.Delay(2500);
            Vector3 direction = player.position - transform.position;
            direction.Normalize();


            transform.position += direction * speed * Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tigerAnimator.Play("Eat");
            SceneManager.LoadScene(3);
        }
    }
}
