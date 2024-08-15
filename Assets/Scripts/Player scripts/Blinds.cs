using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Blinds : MonoBehaviour
{
    RaycastHit hit1;

    [SerializeField] float rayLength;
    [SerializeField] int blindsIndex;
    [SerializeField] LayerMask blindsLayer;
    [SerializeField] bool isBlinds, isBlindsOpen;
    [SerializeField] GameObject blinds;
    [SerializeField] Animator blindsAnimator;
    [SerializeField] AudioSource blindsAudio;
    [SerializeField] TextMeshProUGUI blindsTask;


    void BlindsOpen()
    {
        bool isRay = Physics.Raycast(transform.position, transform.forward, out hit1, rayLength, blindsLayer);

        if (isRay)
        {
            isBlinds = true;
            blinds = hit1.collider.gameObject;
            blindsAnimator = blinds.GetComponent<Animator>();
            blindsAudio = blinds.GetComponent<AudioSource>();
            

            if (Input.GetKeyDown(KeyCode.E) && isBlinds && blindsIndex % 2 != 0)
            {
                Debug.Log("Blinds open");

                blindsIndex++;
                isBlindsOpen = true;

                blindsAnimator.Play("Open Curtain");

                blindsTask.color = Color.green;

                if (blindsAudio != null)
                {
                    blindsAudio.Play();
                }
            }

            if (Input.GetKeyDown(KeyCode.E) && isBlindsOpen && blindsIndex % 2 == 0)
            {
                Debug.Log("Blinds close");

                blindsIndex++;
                isBlindsOpen = false;

                blindsAnimator.Play("Close Curtain");

                if (blindsAudio != null)
                {
                    blindsAudio.Play();
                }
            }
        }

        else if (!isRay)
        {
            isBlinds = false;
            blinds = null;
            blindsAnimator = null;
            blindsAudio = null;
        }
    }

    private void Update()
    {
        BlindsOpen();
    }
}
