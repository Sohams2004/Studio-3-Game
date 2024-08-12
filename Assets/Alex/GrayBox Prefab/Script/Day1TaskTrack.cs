using UnityEngine;

public class Day1TaskTrack : MonoBehaviour
{
    public bool alltaskdone = false;
    [SerializeField] PickUpPlace pickupPlace;
    [SerializeField] ShopUI shopUI;
    [SerializeField] ParentRoomKey parentRoomKey;
    [SerializeField] ObjectPickUp objectPickUp;
    [SerializeField] AntipsychoticsDrug antipsychoticsDrug;

    // Update is called once per frame
    void Update()
    {
        if (pickupPlace.eatdone && shopUI.shopdone && parentRoomKey.keydone && objectPickUp.moneydone && antipsychoticsDrug.medicinedone)
        {
            alltaskdone = true;
        }
    }
}
