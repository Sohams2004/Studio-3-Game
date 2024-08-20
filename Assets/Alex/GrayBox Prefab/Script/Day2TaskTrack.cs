using UnityEngine;

public class Day2TaskTrack : MonoBehaviour
{
    [SerializeField] NewLightSwitch lightSwitch;
    [SerializeField] PickUpPlace pickUpPlace;
    [SerializeField] LaundryScript laundryScript;
    [SerializeField] Television television;
    [SerializeField] Piano piano;
    [SerializeField] Blinds blinds;
    public bool firstdaytaskdone = false;


    // Update is called once per frame
    void Update()
    {
        if (piano.playPianoDone && television.tvDone && pickUpPlace.eatdone && laundryScript.laundryTask && lightSwitch.lightdone || blinds.lighton && piano.playPianoDone && television.tvDone && pickUpPlace.eatdone && laundryScript.laundryTask)
        {
            firstdaytaskdone = true;
        }
    }
}
