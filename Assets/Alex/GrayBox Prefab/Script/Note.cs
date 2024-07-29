using System.Threading.Tasks;
using UnityEngine;

public class Note : MonoBehaviour
{
    public GameObject targetObject;
    public GameObject indicator;
    [SerializeField] bool isInside = false;
    [SerializeField] bool isActive = false;


    private void Start()
    {
        targetObject.SetActive(false);
        indicator.SetActive(false);

    }
    private async void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isActive && isInside)
        {
            targetObject.SetActive(true);
            await Task.Delay(100);
            isActive = true;

        }
        if (Input.GetKeyDown(KeyCode.E) && isActive && isInside)
        {
            targetObject.SetActive(false);
            await Task.Delay(100);
            isActive = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isActive)
            {
                isInside = true;
            }
            else if (isActive)
            {
                isInside = true;
            }

        }
    }

    /*  void OnTriggerExit(Collider other)
      {
          if (other.CompareTag("Player"))  // Check if the player exited the trigger
          {
              isInside = false;
              targetObject.SetActive(false);
              isActive = false;
              *//*targetObject.SetActive(false);*//*
          }
      }*/
}
