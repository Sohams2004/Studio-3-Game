using UnityEngine;
using UnityEngine.UIElements;

public class Day1TaskTrack : MonoBehaviour
{
    public bool alltaskdone = false;
    [SerializeField] PickUpPlace pickupPlace;
    [SerializeField] ShopUI shopUI;
    [SerializeField] ParentRoomKey parentRoomKey;
    [SerializeField] MoneyCollect moneyCollect;
    [SerializeField] AntipsychoticsDrug antipsychoticsDrug;

    // Update is called once per frame

    private void Start()
    {
        pickupPlace = FindObjectOfType<PickUpPlace>();
        shopUI = FindObjectOfType<ShopUI>();
        parentRoomKey = FindObjectOfType<ParentRoomKey>();
        moneyCollect = FindObjectOfType<MoneyCollect>();
        antipsychoticsDrug = FindObjectOfType<AntipsychoticsDrug>();
    }

    void Update()
    {
        if (pickupPlace.eatdone && shopUI.shopdone && parentRoomKey.keydone && moneyCollect.moneydone && antipsychoticsDrug.medicinedone)
        {
            alltaskdone = true;
        }
    }
}
