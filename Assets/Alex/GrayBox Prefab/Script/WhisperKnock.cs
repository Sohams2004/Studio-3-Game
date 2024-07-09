using TMPro;
using UnityEngine;

public class WhisperKnock : MonoBehaviour
{
    [SerializeField] AudioSource whisper;
    [SerializeField] AudioSource knock;
    [SerializeField] TMP_Text doortext;
    [SerializeField] ParentRoomKey roomKey;
    [SerializeField] DoorAnimation doorAnimation;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            whisper.Play();
            doortext.text = "Parent Room";
            if (Input.GetKeyDown(KeyCode.E) && !roomKey.pickedkey)
            {
                knock.Play();
                doortext.text = "Locked";
            }
            if (doorAnimation.state == DoorAnimation.State.Close)
            {
                doortext.text = "Press E to Open";
                if (Input.GetKeyDown(KeyCode.E) && roomKey.pickedkey)
                {

                    whisper.Stop();
                    knock.Stop();
                    doorAnimation.ChangeDoorState();


                }

                else if (doorAnimation.state == DoorAnimation.State.Open)
                {
                    doortext.text = "Press E to Close";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        doorAnimation.ChangeDoorState();
                    }
                }
            }
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                knock.Play();
                doortext.text = "Locked";
            }
            if (doorAnimation.state == DoorAnimation.State.Close)
            {
                doortext.text = "Press E to Open";
                if (Input.GetKeyDown(KeyCode.E) && roomKey.pickedkey)
                {

                    whisper.Stop();
                    knock.Stop();
                    doorAnimation.ChangeDoorState();


                }

                else if (doorAnimation.state == DoorAnimation.State.Open)
                {
                    doortext.text = "Press E to Close";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        doorAnimation.ChangeDoorState();
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
