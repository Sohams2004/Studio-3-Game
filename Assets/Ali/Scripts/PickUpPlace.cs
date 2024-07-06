using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickUpPlace : MonoBehaviour
{
  private GameObject pickedObject;
    public float pickUpRange = 2.0f;
    public float holdDistance = 0.7f;
    public LayerMask pickUpLayer;

    private GameObject orangeJuice;
    public TextMeshPro drinkText;
    public AudioSource drinkSound;

    private bool isLookingAtOrangeJuice = false;

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

        CheckForInteraction();

        if (isLookingAtOrangeJuice && Input.GetKeyDown(KeyCode.F))
        {
            DrinkOrangeJuice();
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

    void CheckForInteraction()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, pickUpRange, pickUpLayer))
        {
            if (hit.collider.gameObject.CompareTag("OrangeJuice"))
            {
                orangeJuice = hit.collider.gameObject;
                drinkText.transform.position = orangeJuice.transform.position + new Vector3(0, 1, 0);
                drinkText.gameObject.SetActive(true);
                isLookingAtOrangeJuice = true;
            }
            else
            {
                drinkText.gameObject.SetActive(false);
                isLookingAtOrangeJuice = false;
            }
        }
        else
        {
            drinkText.gameObject.SetActive(false);
            isLookingAtOrangeJuice = false;
        }
    }

    void DrinkOrangeJuice()
    {
        Destroy(orangeJuice);
        drinkText.gameObject.SetActive(false);
        drinkSound.Play();
        isLookingAtOrangeJuice = false;
    }
}
