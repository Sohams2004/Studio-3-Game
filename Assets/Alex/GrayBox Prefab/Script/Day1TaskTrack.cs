using UnityEngine;

public class Day1TaskTrack : MonoBehaviour
{
    public bool alltaskdonetwo = false;
    [SerializeField] PickUpPlace pickupPlace;
    [SerializeField] ShopUI shopUI;
    [SerializeField] ParentRoomKey parentRoomKey;
    [SerializeField] MoneyCollect moneyCollect;
    [SerializeField] AntipsychoticsDrug antipsychoticsDrug;
    [SerializeField] FrontDoorKey frontDoorKey;

    // Update is called once per frame

    void Update()
    {

        if (frontDoorKey.pickedkeysittingroom && pickupPlace.eatdone && shopUI.shopdone && parentRoomKey.keydone && moneyCollect.moneydone)
        {
            alltaskdonetwo = true;
        }
    }
}
