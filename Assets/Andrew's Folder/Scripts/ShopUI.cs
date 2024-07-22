using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    RaycastHit hit1;

    GameObject money;

    [SerializeField] float rayLength;

    [SerializeField] public float moneyCount;

    [SerializeField] LayerMask moneyLayer;

    [SerializeField] TextMeshProUGUI pickUpMoneyText, moneyCountText;

    [SerializeField] GameObject shopUI;

    [SerializeField] float breadPrice, eggPrice, orangePrice;

    [SerializeField] GameObject breadPrefab, eggPrefab, orangePrefab;

    [SerializeField] Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        shopUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Money();
    }

    /*void Money()
    {
        //bool isRay = Physics.Raycast(transform.position, transform.forward, out hit1, rayLength, moneyLayer);
        if (isRay)
        {

            money = hit1.collider.gameObject;
            pickUpMoneyText.text = "Press E to pick up Money";

            if (Input.GetKeyDown(KeyCode.E))
            {
                moneyCount += 5f;
                moneyCountText.text = string.Format("$ " + moneyCount);
                money.SetActive(false);
            }
        }

        if (!isRay)
        {
            pickUpMoneyText.text = string.Empty;
        }
    }*/

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pay Station"))
        {
            shopUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pay Station"))
        {
            shopUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void BuyBread()
    {
        if (moneyCount >= breadPrice)
        {
            Debug.Log("Purachased Bread");

            moneyCount -= breadPrice;
            moneyCountText.text = string.Format("$ " + moneyCount);
            Instantiate(breadPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }

    public void BuyEgg()
    {
        if (moneyCount >= eggPrice)
        {
            Debug.Log("Purachased eggs");

            moneyCount -= eggPrice;
            moneyCountText.text = string.Format("$ " + moneyCount);
            Instantiate(eggPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }

    public void BuyOrange()
    {
        if (moneyCount >= orangePrice)
        {
            Debug.Log("Purachased orange");

            moneyCount -= orangePrice;
            moneyCountText.text = string.Format("$ " + moneyCount);
            Instantiate(orangePrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }

    public void CloseUI()
    {
        shopUI.SetActive(false);
    }
}
