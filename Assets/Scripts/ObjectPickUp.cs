using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickUp : MonoBehaviour
{
    [SerializeField] float rayLength;

    [SerializeField] Transform pickUpPoint;

    [SerializeField] LayerMask pickableObj;

    [SerializeField] Rigidbody objectRb;

    [SerializeField] GameObject pickableObject;

    [SerializeField] Camera camera;

    RaycastHit hit1;

    private void Start()
    {
        camera = Camera.main;
    }

    void ObjectDetect()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit1, rayLength, pickableObj))
        {
            Debug.Log("Object detected");
            GameObject hitObj = hit1.collider.gameObject;

            if (Input.GetKeyDown(KeyCode.E))
            {
                objectRb = hitObj.GetComponent<Rigidbody>();
                pickableObject = hitObj.gameObject;
                hitObj.transform.position = pickUpPoint.position;
                hitObj.transform.parent = camera.transform;
                objectRb.constraints = RigidbodyConstraints.FreezeAll;
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                hitObj.transform.parent = null;
                objectRb.constraints = RigidbodyConstraints.None;
            }
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
