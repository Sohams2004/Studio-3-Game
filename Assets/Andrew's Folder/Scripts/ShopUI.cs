using TMPro;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    RaycastHit hit1;

    GameObject money;

    [SerializeField] float rayLength;

    [SerializeField] public float moneyCount;

    [SerializeField] LayerMask moneyLayer;

    [SerializeField] TextMeshProUGUI pickUpMoneyText, moneyCountText;
    [SerializeField] TMP_Text InteractText;

    [SerializeField] GameObject shopUI;

    [SerializeField] float breadPrice, eggPrice, orangePrice;

    [SerializeField] GameObject breadPrefab, eggPrefab, orangePrefab;

    [SerializeField] Transform spawnPoint;

    [SerializeField] bool inside;

    // Start is called before the first frame update
    void Start()
    {
        inside = false;
        shopUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (inside && Input.GetKey(KeyCode.E))
        {

            shopUI.SetActive(true);
            InteractText.text = string.Empty;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
        }

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
            inside = true;
            InteractText.text = "Press E to Interact";

        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Pay Station"))
        {
            inside = true;
            InteractText.text = "Press E to Interact";


        }
    }
    private void OnTriggerExit(Collider other)
    {
        shopUI.SetActive(false);
        InteractText.text = string.Empty;
        inside = false;
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
        Time.timeScale = 1;
        shopUI.SetActive(false);
        InteractText.text = string.Empty;
        inside = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
