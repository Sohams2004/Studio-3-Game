using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ObjectPickUp : MonoBehaviour
{
    [SerializeField] float rayLength;

    [SerializeField] int paperNoteIndex;

    [SerializeField] bool isObject, isPicked, isPaperNote, isPaperNotePicked, cannotPickUp;

    [SerializeField] Transform pickUpPoint;

    [SerializeField] LayerMask pickableObj, paperNoteLayer, placeLayer;

    [SerializeField] Rigidbody objectRb;

    [SerializeField] GameObject pickableObject;

    [SerializeField] Camera camera;

    [SerializeField] TextMeshProUGUI playerIndicationText;

    [SerializeField] Image crosshair, paperNote;

    RaycastHit hit1;
    GameObject hitObj;

    private void Start()
    {
        camera = Camera.main;
    }

    void ObjectDetect()
    {
        bool isRay = Physics.Raycast(transform.position, transform.forward, out hit1, rayLength, pickableObj);
        if (isRay)
        {
            Debug.Log("Object detected");
            hitObj = hit1.collider.gameObject;
            crosshair.color = Color.green;
            isObject = true;
        }

        else if(!isRay)
        {
            isObject = false;
            playerIndicationText.text = string.Empty;
            crosshair.color = Color.red;
        }

        if (Input.GetKeyDown(KeyCode.E) && isObject && !cannotPickUp)
        {
            cannotPickUp = true;
            isPicked = true;
            objectRb = hitObj.GetComponent<Rigidbody>();
            pickableObject = hitObj.gameObject;
            hitObj.transform.position = pickUpPoint.position;
            hitObj.transform.parent = camera.transform;
            objectRb.constraints = RigidbodyConstraints.FreezeAll;
            playerIndicationText.text = string.Empty;
        }

        if (isObject)
            playerIndicationText.text = "Press E to pick up";

        else if (isPicked)
        {
            playerIndicationText.text = "Press Q to Drop";
        }

        if (Input.GetKeyDown(KeyCode.Q) && isPicked)
        {
            cannotPickUp = false;
            isPicked = false;
            hitObj.transform.parent = null;
            objectRb.constraints = RigidbodyConstraints.None;
            playerIndicationText.text = string.Empty;
        }
    }

    void PaperNote()
    {
        bool isRay = Physics.Raycast(transform.position, transform.forward, out hit1, rayLength, paperNoteLayer);
        if (isRay)
        {
            Debug.Log("Note detected");

            isPaperNote = true;

            if (!isPaperNotePicked)
                playerIndicationText.text = "Press E to interact";
        }

        else if(!isRay)
        {
            isPaperNote = false;
            playerIndicationText.text = string.Empty;
        }


        if (Input.GetKeyDown(KeyCode.E) && isPaperNote && paperNoteIndex % 2 != 0)
        {
            paperNoteIndex++;
            isPaperNotePicked = true;
            paperNote.gameObject.SetActive(true);
        }

        else if (Input.GetKeyDown(KeyCode.E) && isPaperNotePicked && paperNoteIndex % 2 == 0)
        {
            paperNoteIndex++;
            isPaperNote = false;
            isPaperNotePicked = false;
            paperNote.gameObject.SetActive(false);
        }

        if (isPaperNotePicked)
        {
            playerIndicationText.text = string.Empty;
        }
    }

    void PlaceObjects()
    {
        bool isRay = Physics.Raycast(transform.position, transform.forward, out hit1, rayLength, placeLayer) && isPicked;
        if (isRay)
        {
            Debug.Log("Place detected");
            GameObject place = hit1.collider.gameObject;
            crosshair.color = Color.green;
            playerIndicationText.text = "Place object";

            if (Input.GetMouseButtonDown(0))
            {
                cannotPickUp = false;
                pickableObject.transform.position = place.transform.position;
                pickableObject.transform.rotation = Quaternion.identity;
                objectRb.constraints = RigidbodyConstraints.None;
                hitObj.transform.parent = null;
            }
        }

        else if(!isRay)
        {
            crosshair.color = Color.red;
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
        PaperNote();
        PlaceObjects();
    }
}
