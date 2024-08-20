using System.Threading.Tasks;
using UnityEngine;

public class Note : MonoBehaviour
{
    public GameObject targetObject;
    [SerializeField] bool isInside = false;
    [SerializeField] bool isActive = false;


    private void Start()
    {
        targetObject.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && isInside)
        {
            PopUp();
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInside = true;


        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInside = true;


        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInside = false;
            targetObject.SetActive(false);
            isActive = false;

        }
    }
    async void PopUp()
    {

        if (!isActive)
        {
            targetObject.SetActive(true);
            await Task.Delay(100);
            isActive = true;
        }
        else if (isActive)
        {
            targetObject.SetActive(false);
            await Task.Delay(100);
            isActive = false;
        }
    }
}
