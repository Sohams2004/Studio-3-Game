using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    RaycastHit hit1;
    [SerializeField] float rayLength;
    [SerializeField] int shopIndex;
    [SerializeField] LayerMask shopLayer;
    [SerializeField] bool isShop, isShopOn;

    [SerializeField] GameObject shopUi;

    void ShopInteraction()
    {
        bool isRay = Physics.Raycast(transform.position, transform.forward, out hit1, rayLength, shopLayer);

        if (isRay)
        {
            isShop = true;

            if (Input.GetKeyDown(KeyCode.E) && isShop && shopIndex % 2 != 0)
            {
                isShopOn = true;
                shopUi.SetActive(true);
                shopUi.transform.GetChild(0).gameObject.SetActive(false);
                shopUi.transform.GetChild(1).gameObject.SetActive(false);
                shopUi.transform.GetChild(2).gameObject.SetActive(false);

                shopIndex++;

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

            if (Input.GetKeyDown(KeyCode.E) && isShopOn && shopIndex % 2 == 0)
            {
                isShopOn = false;
                shopUi.SetActive(true);
                shopIndex++;
            }
        }

        else if (!isRay)
        {
            isShop = false;
        }
    }

    private void Update()
    {
        ShopInteraction();
    }
}
