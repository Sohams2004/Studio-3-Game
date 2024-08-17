using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class WhisperKnock : MonoBehaviour
{

    [SerializeField] AudioSource knock;
    [SerializeField] TMP_Text doortext;
    [SerializeField] ParentRoomKey roomKey;
    [SerializeField] DoorAnimationInGame doorAnimation;
    [SerializeField] bool isNowOpen = false;
    private async void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !doorAnimation.isOpen && doorAnimation.inDoor)
        {
            doorAnimation.OpenDoor();
            await Task.Delay(2000);
            doorAnimation.isOpen = true;
        }

        if (doorAnimation.isOpen && doorAnimation.inDoor)
        {
            doortext.text = string.Empty;
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                doorAnimation.CloseDoor();
                await Task.Delay(1800);
                doorAnimation.isOpen = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            doortext.text = "Parent Room";
            if (Input.GetKeyDown(KeyCode.Mouse0) && !roomKey.pickedkey)
            {
                knock.Play();
                doortext.text = "Locked";
            }
            if (roomKey.pickedkey && !isNowOpen)
            {

                knock.Stop();
                doortext.text = string.Empty;
                doorAnimation.inDoor = true;

            }
        }

    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {


            if (Input.GetKeyDown(KeyCode.E) && !roomKey.pickedkey)
            {
                knock.Play();
                doortext.text = "Locked";
            }
            if (roomKey.pickedkey && !isNowOpen)
            {
                knock.Stop();
                doorAnimation.inDoor = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        doorAnimation.inDoor = false;
        doortext.text = string.Empty;
    }
}
