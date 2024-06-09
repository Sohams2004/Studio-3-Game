using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPickUp : MonoBehaviour
{
    [SerializeField] float rayLength;

    [SerializeField] bool isPicked;

    [SerializeField] Transform pickUpPoint;

    [SerializeField] LayerMask pickableObj;

    [SerializeField] Rigidbody objectRb;

    [SerializeField] GameObject pickableObject;

    [SerializeField] Camera camera;

    [SerializeField] TextMeshProUGUI playerIndicationText;

    [SerializeField] Image crosshair;

    RaycastHit hit1;
    GameObject hitObj;

    private void Start()
    {
        camera = Camera.main;
    }

    void ObjectDetect()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit1, rayLength, pickableObj))
        {
            Debug.Log("Object detected");
            hitObj = hit1.collider.gameObject;
            crosshair.color = Color.green;

            if(!isPicked)
                playerIndicationText.text = "Press E to pick up";

            if (Input.GetKeyDown(KeyCode.E))
            {
                isPicked = true;
                objectRb = hitObj.GetComponent<Rigidbody>();
                pickableObject = hitObj.gameObject;
                hitObj.transform.position = pickUpPoint.position;
                hitObj.transform.parent = camera.transform;
                objectRb.constraints = RigidbodyConstraints.FreezeAll;
                playerIndicationText.text = string.Empty;
                playerIndicationText.text = "Press Q to Drop";
            }
        }

        else
        {
            playerIndicationText.text = string.Empty;
            crosshair.color = Color.red;
        }

        if (Input.GetKeyDown(KeyCode.Q) && isPicked)
        {
            isPicked = false;
            hitObj.transform.parent = null;
            objectRb.constraints = RigidbodyConstraints.None;
            playerIndicationText.text = string.Empty;
        } 
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward * rayLength);
    }

    private void Update()
    {
        ObjectDetect();
    }
}
