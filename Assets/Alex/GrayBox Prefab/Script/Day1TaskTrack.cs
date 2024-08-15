using UnityEngine;

public class Day1TaskTrack : MonoBehaviour
{
    public bool alltaskdone = false;
    [SerializeField] PickUpPlace pickupPlace;
    [SerializeField] ShopUI shopUI;
    [SerializeField] ParentRoomKey parentRoomKey;
    [SerializeField] MoneyCollect moneyCollect;
    [SerializeField] AntipsychoticsDrug antipsychoticsDrug;
    [SerializeField] FrontDoorKey frontDoorKey;

    // Update is called once per frame

    void Update()
    {
        if (frontDoorKey.key2done && pickupPlace.eatdone && shopUI.shopdone && parentRoomKey.keydone && moneyCollect.moneydone && antipsychoticsDrug.medicinedone)
        {
            alltaskdone = true;
        }
    }
}
