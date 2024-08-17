using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class SittingRoom : MonoBehaviour
{

    [SerializeField] AudioSource knock;
    [SerializeField] TMP_Text doortext;
    [SerializeField] FrontDoorKey doorKey;
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
            doortext.text = "Locked";
            if (Input.GetKeyDown(KeyCode.Mouse0) && !doorKey.pickedkeysittingroom)
            {
                knock.Play();
                doortext.text = "Locked";
            }
            if (doorKey.pickedkeysittingroom && !isNowOpen)
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
            doortext.text = "Locked";
            if (Input.GetKeyDown(KeyCode.E) && !doorKey.pickedkeysittingroom)
            {
                knock.Play();
                doortext.text = "Locked";
            }
            if (doorKey.pickedkeysittingroom && !isNowOpen)
            {
                knock.Stop();
                doorAnimation.inDoor = true;
                doortext.text = string.Empty;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        doorAnimation.inDoor = false;
        doortext.text = string.Empty;
    }
}
