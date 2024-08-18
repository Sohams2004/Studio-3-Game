using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sitting3 : MonoBehaviour
{
    public Animator playerAnimator;  
    public Transform sittingPoint;   
    public KeyCode sitKey = KeyCode.E; 

    private bool isSitting = false;   
    private Vector3 originalPosition; 
    private Quaternion originalRotation; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Chair") && !isSitting)
        {
            SitOnChair();
        }
    }

    private void Update()
    {
        if (isSitting && Input.GetKeyDown(sitKey))
        {
            StandUp();
        }
    }

    private void SitOnChair()
    {
        
        originalPosition = transform.position;
        originalRotation = transform.rotation;

        
        transform.position = sittingPoint.position;
        transform.rotation = sittingPoint.rotation;

        playerAnimator.SetTrigger("Sit");


        isSitting = true;
    }

    private void StandUp()
    {
        
        transform.position = originalPosition;
        transform.rotation = originalRotation;

        
        playerAnimator.SetTrigger("StandUp");


        isSitting = false;
    }
}
