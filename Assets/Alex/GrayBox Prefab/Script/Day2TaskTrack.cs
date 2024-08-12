using UnityEngine;

public class Day2TaskTrack : MonoBehaviour
{
    [SerializeField] ObjectPickUp objectPickUp;
    [SerializeField] NewLightSwitch lightSwitch;
    [SerializeField] PickUpPlace pickUpPlace;
    [SerializeField] LaundryScript laundryScript;
    public bool firstdaytaskdone = false;

    // Update is called once per frame
    void Update()
    {
        if (objectPickUp.cleanupDone && objectPickUp.tvdone && lightSwitch.lightdone && pickUpPlace.eatdone && laundryScript.laundryTask)
        {
            firstdaytaskdone = true;
        }
    }
}
