using TMPro;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] TMP_Text doortext;
    [SerializeField] AudioSource opendoor;
    [SerializeField] AudioSource closedoor;
    enum State { Close, Open };
    State state;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (state == State.Close)
            {
                doortext.text = "Press E to Open";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    ChangeDoorState();
                }
            }

            else if (state == State.Open)
            {
                doortext.text = "Press E to Close";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    ChangeDoorState();
                }
            }

        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (state == State.Close)
            {
                doortext.text = "Press E to Open";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    ChangeDoorState();
                }
            }

            else if (state == State.Open)
            {
                doortext.text = "Press E to Close";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    ChangeDoorState();
                }
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        doortext.text = string.Empty;
    }
    void ChangeDoorState()
    {

        if (state == State.Close)
        {
            closedoor.Stop();
            opendoor.Play();
            animator.SetBool("Open", true);
            animator.SetBool("Close", false);
            state = State.Open;

        }
        else if (state == State.Open)
        {
            opendoor.Stop();
            closedoor.Play();
            animator.SetBool("Open", false);
            animator.SetBool("Close", true);
            state = State.Close;

        }
    }
}
