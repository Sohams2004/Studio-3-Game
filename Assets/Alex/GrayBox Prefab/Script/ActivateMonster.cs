using UnityEngine;

public class ActivateMonster : MonoBehaviour
{
    [SerializeField] GameObject zombie;
    [SerializeField] AudioSource shriek;
    void Start()
    {
        zombie.SetActive(false);
        shriek.Stop();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            zombie.SetActive(true);
            shriek.Play();
        }
    }
}
