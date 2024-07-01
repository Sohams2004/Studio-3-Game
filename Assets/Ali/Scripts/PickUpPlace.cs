using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPlace : MonoBehaviour
{
   private GameObject pickedObject;
    public float pickUpRange = 2.0f;
    public float holdDistance = 2.0f;
    public LayerMask pickUpLayer;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            if (pickedObject == null)
            {
                PickUp();
            }
            else
            {
                Place();
            }
        }

        if (pickedObject != null)
        {
            HoldObject();
        }
    }

    void PickUp()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, pickUpRange, pickUpLayer))
        {
            if (hit.collider.gameObject.GetComponent<Rigidbody>())
            {
                pickedObject = hit.collider.gameObject;
                pickedObject.GetComponent<Rigidbody>().useGravity = false;
                pickedObject.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }

    void Place()
    {
        pickedObject.GetComponent<Rigidbody>().useGravity = true;
        pickedObject.GetComponent<Rigidbody>().isKinematic = false;
        pickedObject = null;
    }

    void HoldObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        pickedObject.transform.position = ray.GetPoint(holdDistance);
    }
}
