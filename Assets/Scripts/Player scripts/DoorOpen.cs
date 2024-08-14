using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DoorOpen : MonoBehaviour
{
    RaycastHit hit1;

    [SerializeField] float rayLength;
    [SerializeField] int doorIndex;
    [SerializeField] LayerMask doorLayer;
    [SerializeField] bool isDoor, isDoorOpen;
    [SerializeField] GameObject door;
    [SerializeField] Animator doorAnimator;

    [SerializeField] AudioSource opendoor;
    [SerializeField] AudioSource closedoor;

    async void OpenDoor()
    {
        bool isRay = Physics.Raycast(transform.position, transform.forward, out hit1, rayLength, doorLayer);

        if (isRay)
        {
            isDoor = true;
            door = hit1.collider.gameObject;
            doorAnimator = door.GetComponent<Animator>();
            if (Input.GetKeyDown(KeyCode.E) && isDoor && doorIndex % 2 != 0)
            {
                doorIndex++;
                isDoorOpen = true;
                doorAnimator.Play("Door Open");
                //closedoor.Stop();
                //opendoor.Play();
                await Task.Delay(2000);

            }

            else if (Input.GetKeyDown(KeyCode.E) && isDoorOpen && doorIndex % 2 == 0)
            {
                doorIndex++;
                isDoorOpen = false;
                doorAnimator.Play("Door Close");
                //opendoor.Stop();
                //closedoor.Play();
                await Task.Delay(2000);

            }
        }

        else if (!isRay)
        {
            isDoor = false;
            door = null;
            doorAnimator = null;
        }
    }

    private void Update()
    {
        OpenDoor();
    }
}
