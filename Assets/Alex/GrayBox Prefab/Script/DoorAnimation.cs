using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] TMP_Text doortext;
    [SerializeField] AudioSource opendoor;
    [SerializeField] AudioSource closedoor;
    [SerializeField] bool isOpen = false;
    [SerializeField] bool inDoor = false;


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
            }
            if (isOpen)
            {
                inDoor = true;
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
        animator.Play("Door Opening");



    }
    public void CloseDoor()
    {
        opendoor.Stop();
        closedoor.Play();
        animator.Play("Door Closing");


    }
}
