using UnityEngine;

public class CarFear2 : MonoBehaviour
{
    [SerializeField] GameObject car;

    private void Start()
    {
        car.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            car.SetActive(true);
            Destroy(gameObject);
        }

    }
}
