using System.Collections.Generic;
using UnityEngine;

public class HotBar : MonoBehaviour
{

    public List<GameObject> items;
    public List<GameObject> inventory;

    [SerializeField] GameObject item1, item2, item3, item4, item5;

    [SerializeField] public GameObject currentObject;

    [SerializeField] public int numberOfItems;

    [SerializeField] int direction;

    [SerializeField] bool itemsFull;

    ObjectPickUp objectPickUp;

    private void Start()
    {
        objectPickUp = FindObjectOfType<ObjectPickUp>();
        //items = new GameObject[numberOfItems];
    }

    void ToggleItems(float mouseScroll)
    {
        /*for (int i = 0; i < items.Length; i++)
        {
            if (items[i] != null)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1) && items[0] != null)
                {
                    DisableItems();
                    item1 = items[0];
                    items[0].SetActive(true);
                    currentObject = items[0];
                    objectPickUp.pickableObject = currentObject;
                    objectPickUp.objectRb = currentObject.GetComponent<Rigidbody>();
                }

                else if (Input.GetKeyDown(KeyCode.Alpha2) && items[1] != null)
                {
                    DisableItems();
                    item2 = items[1];
                    items[1].SetActive(true);
                    currentObject = items[1];
                    objectPickUp.pickableObject = currentObject;
                    objectPickUp.objectRb = currentObject.GetComponent<Rigidbody>();
                }

                else if (Input.GetKeyDown(KeyCode.Alpha3) && items[2] != null)
                {
                    DisableItems();
                    item3 = items[2];
                    items[2].SetActive(true);
                    currentObject = items[2];
                    objectPickUp.pickableObject = currentObject;
                    objectPickUp.objectRb = currentObject.GetComponent<Rigidbody>();
                }
            }
        }/



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


        
        
            int currentIndex = -1;

            if( mouseScroll > 0 )
            {
                direction = 1;
            }
            else
            {
                direction = -1;
            }

            for ( int i = 0; i < items.Count; i++ )
            {
                if (items[i] != null && items[i].activeSelf)
                {
                    currentIndex = i;
                    break;
                }
            }

            if (currentIndex == -1)
            {
                currentIndex = 0;
            }

            for (int i = 0; i < items.Count; i++)
            {
                int newIndex = (currentIndex + direction + items.Count) % items.Count;
                if (items[newIndex] is not null)
                {
                    DisableItems();
                    items[newIndex].SetActive(true);
                    currentObject = items[newIndex];
                objectPickUp.pickableObject = currentObject;
                    objectPickUp.objectRb = currentObject.GetComponent<Rigidbody>();

                    Debug.Log(items[newIndex]);
                    break;
                }
            }    
    }

    /*public void Inventory()
    {
        if (items[0] != null && items[1] != null && items[2] != null)
        {
            itemsFull = true;
        }

        else
        {
            itemsFull = false;
        }

        if (itemsFull && objectPickUp.pickableObject != null)
        {
            print(objectPickUp.pickableObject);
            inventory.Add(objectPickUp.pickableObject);
        }
    }*/


    void DisableItems()
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] != null)
            {
                items[i].SetActive(false);
            }
        }
    }

    private void Update()
    {
        float mouseScroll = Input.GetAxis("Mouse ScrollWheel");
        if (mouseScroll != 0)
        {
            ToggleItems(mouseScroll);
        }
    }
}

