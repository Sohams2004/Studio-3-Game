using TMPro;
using UnityEngine;

public class MoneyCollect : MonoBehaviour
{
    RaycastHit hit1;

    [SerializeField] float rayLength;
    [SerializeField] LayerMask moneyLayer;
    [SerializeField] GameObject money;
    [SerializeField] TextMeshProUGUI moneyCountText, CashTask;
    public bool moneydone = false;


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


            if (Input.GetKeyDown(KeyCode.Mouse0))
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

        }
    }

    private void Update()
    {
        Money();
    }
}
