using UnityEngine;

public class StoveInteract : MonoBehaviour
{

    [SerializeField] private GameObject smokeEffect;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            smokeEffect.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            smokeEffect.SetActive(false);
        }
    }
}
