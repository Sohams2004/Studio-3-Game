using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class DoorAnimationInGame : MonoBehaviour
{

    [SerializeField] TMP_Text doortext;
    [SerializeField] AudioSource opendoor;
    [SerializeField] AudioSource closedoor;
    [SerializeField] bool isOpen = false;
    [SerializeField] bool inDoor = false;
    [SerializeField] Animator doorAnimator;

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
        doorAnimator.Play("Door Opening");
        closedoor.Stop();
        opendoor.Play();





    }
    public void CloseDoor()
    {
        doorAnimator.Play("Door Closing");
        opendoor.Stop();
        closedoor.Play();



    }
}
