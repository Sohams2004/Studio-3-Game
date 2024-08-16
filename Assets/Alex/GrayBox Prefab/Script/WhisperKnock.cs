using TMPro;
using UnityEngine;

public class WhisperKnock : MonoBehaviour
{

    [SerializeField] AudioSource knock;
    [SerializeField] TMP_Text doortext;
    [SerializeField] ParentRoomKey roomKey;
    [SerializeField] DoorAnimationInGame doorAnimation;
    [SerializeField] bool isNowOpen = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            doortext.text = "Parent Room";
            if (Input.GetKeyDown(KeyCode.E) && !roomKey.pickedkey)
            {
                knock.Play();
                doortext.text = "Locked";
            }
            if (roomKey.pickedkey && !isNowOpen)
            {

                knock.Stop();
                doortext.text = "Press E to Open";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    doorAnimation.OpenDoor();
                    isNowOpen = true;
                }

                if (isNowOpen)
                {
                    doortext.text = "Press E to Close";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        doorAnimation.CloseDoor();
                        isNowOpen = false;
                    }
                }
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
                doortext.text = "Press E to Open";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    doorAnimation.OpenDoor();
                    isNowOpen = true;
                }

                if (isNowOpen)
                {
                    doortext.text = "Press E to Close";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        doorAnimation.CloseDoor();
                        isNowOpen = false;
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        doortext.text = string.Empty;
    }
}
