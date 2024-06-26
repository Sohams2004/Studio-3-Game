using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HotBar : MonoBehaviour
{
    public GameObject[] items;

    [SerializeField] GameObject item1, item2, item3, item4, item5;

    [SerializeField] public GameObject currentObject;

    ObjectPickUp objectPickUp;

    private void Start()
    {
        objectPickUp = FindObjectOfType<ObjectPickUp>();
    }

    void ToggleItems()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) && items[0] != null)
        {
            DisableItems();
            item1 = items[0];
            items[0].SetActive(true);
            currentObject = items[0];
            objectPickUp.pickableObject = currentObject;
            objectPickUp.objectRb = currentObject.GetComponent<Rigidbody>();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && items[1] != null)
        {
            DisableItems();
            item2 = items[1];
            items[1].SetActive(true);
            currentObject = items[1];
            objectPickUp.pickableObject = currentObject;
            objectPickUp.objectRb = currentObject.GetComponent<Rigidbody>();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && items[2] != null)
        {
            DisableItems();
            item3 = items[2];
            items[2].SetActive(true);
            currentObject = items[2];
            objectPickUp.pickableObject = currentObject;
            objectPickUp.objectRb = currentObject.GetComponent<Rigidbody>();
        }

       /* if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            DisableItems();
            item4 = items[3];
            items[3].SetActive(true);
            currentObject = items[3];
            objectPickUp.pickableObject = currentObject;
            objectPickUp.objectRb = currentObject.GetComponent<Rigidbody>();
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            DisableItems();
            item5 = items[4];
            items[4].SetActive(true);
            currentObject = items[4] ;
            objectPickUp.pickableObject = currentObject;
            objectPickUp.objectRb = currentObject.GetComponent<Rigidbody>();
        }*/
    }

    void DisableItems()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i].SetActive(false);
        }
    }

    private void Update()
    {
        ToggleItems();
    }
}
