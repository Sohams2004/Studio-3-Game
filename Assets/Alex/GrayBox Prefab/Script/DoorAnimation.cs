using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    [SerializeField] LoadingScene scene;
    [SerializeField] TMP_Text doortext;
    [SerializeField] AudioSource opendoor;
    [SerializeField] AudioSource closedoor;
    [SerializeField] bool isOpen = false;
    [SerializeField] bool inDoor = false;

    private void Start()
    {
        scene.LoadingScreen.SetActive(false);
    }
    private async void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isOpen & inDoor)
        {
            OpenDoor();
            await Task.Delay(2000);
            isOpen = true;
        }
        if (Input.GetKeyDown(KeyCode.E) && isOpen & inDoor)
        {
            CloseDoor();
            await Task.Delay(2000);
            isOpen = false;
        }


    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            if (!isOpen)
            {
                inDoor = true;
            }
            if (isOpen)
            {
                inDoor = true;
            }

        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isOpen)
            {
                inDoor = true;
                doortext.text = "Press E to Interact";
            }
            if (isOpen)
            {
                inDoor = true;
                doortext.text = "Press E to Interact";
            }

        }

    }
    private void OnTriggerExit(Collider other)
    {
        inDoor = false;
        doortext.text = string.Empty;
    }
    public void OpenDoor()
    {

        closedoor.Stop();
        opendoor.Play();
        scene.LoadingScreen.SetActive(true);
        scene.LoadScene(3);



    }
    public void CloseDoor()
    {
        opendoor.Stop();
        closedoor.Play();
        scene.LoadingScreen.SetActive(true);
        scene.LoadScene(3);

    }
}
