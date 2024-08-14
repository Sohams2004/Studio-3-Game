using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class MoneyCollect : MonoBehaviour
{
    RaycastHit hit1;

    [SerializeField] float rayLength;
    [SerializeField] LayerMask moneyLayer;
    [SerializeField] GameObject money;
    [SerializeField] TextMeshProUGUI pickUpMoneyText, moneyCountText, CashTask;
    [SerializeField] public bool moneydone = false;


    ShopUI shopUI;

    private void Start()
    {
        shopUI = FindObjectOfType<ShopUI>();
    }

    void Money()
    {
        bool isRay = Physics.Raycast(transform.position, transform.forward, out hit1, rayLength, moneyLayer);
        if (isRay)
        {
            Debug.Log("Money");

            money = hit1.collider.gameObject;
            pickUpMoneyText.text = "Press E to pick up Money";

            if (Input.GetKeyDown(KeyCode.E))
            {
                shopUI.moneyCount += 5f;
                moneyCountText.text = string.Format("$ " + shopUI.moneyCount);
                money.SetActive(false);

                CashTask.text = "Cash Collected"; //two lines to update task text
                CashTask.color = Color.green;
                moneydone = true;

            }
        }

        else if (!isRay)
        {
            money = null;
            pickUpMoneyText.text = string.Empty;
        }
    }

    private void Update()
    {
        Money();
    }
}
