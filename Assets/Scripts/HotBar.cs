using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HotBar : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();

    ObjectPickUp objectPickUp;

    [SerializeField] public GameObject currentObject;

    void ToggleItems()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            DisableItems();
            items[0].SetActive(true);
            currentObject = items[0];
            objectPickUp.pickableObject = currentObject;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DisableItems();
            items[1].SetActive(true);
            currentObject = items[1];
            objectPickUp.pickableObject = currentObject;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            DisableItems();
            items[2].SetActive(true);
            currentObject = items[2];
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            DisableItems();
            items[3].SetActive(true);
            currentObject = items[3];
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            DisableItems();
            items[4].SetActive(true);
            currentObject = items[4] ;
        }
    }

    void DisableItems()
    {
        for (int i = 0; i < items.Count; i++)
        {
            items[i].SetActive(false);
        }
    }

    private void Update()
    {
        ToggleItems();
    }
}
