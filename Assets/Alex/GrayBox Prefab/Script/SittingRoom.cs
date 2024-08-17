using TMPro;
using UnityEngine;

public class SittingRoom : MonoBehaviour
{

    [SerializeField] AudioSource knock;
    [SerializeField] TMP_Text doortext;
    [SerializeField] FrontDoorKey doorKey;
    [SerializeField] DoorAnimationInGame doorAnimation;
    [SerializeField] bool isNowOpen = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

           
            if (Input.GetKeyDown(KeyCode.Mouse0) && !doorKey.pickedkeysittingroom)
            {
                knock.Play();
                doortext.text = "Locked";
            }
            if (doorKey.pickedkeysittingroom && !isNowOpen)
            {

                knock.Stop();
                doortext.text = "Press LeftClick to Open";
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    doorAnimation.OpenDoor();
                    isNowOpen = true;
                }

                if (isNowOpen)
                {
                    doortext.text = "Press LeftClick to Close";
                    if (Input.GetKeyDown(KeyCode.Mouse0))
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

            doortext.text = "Parent Room";
            if (Input.GetKeyDown(KeyCode.Mouse0) && !doorKey.pickedkeysittingroom)
            {
                knock.Play();
                doortext.text = "Locked";
            }
            if (doorKey.pickedkeysittingroom && !isNowOpen)
            {

                knock.Stop();
                doortext.text = "Press LeftClick to Open";
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    doorAnimation.OpenDoor();
                    isNowOpen = true;
                }

                if (isNowOpen)
                {
                    doortext.text = "Press LeftClick to Close";
                    if (Input.GetKeyDown(KeyCode.Mouse0))
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
