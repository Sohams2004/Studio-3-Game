using UnityEngine;

public class Day2TaskTrack : MonoBehaviour
{
    [SerializeField] ObjectPickUp objectPickUp;
    [SerializeField] NewLightSwitch lightSwitch;
    [SerializeField] PickUpPlace pickUpPlace;
    [SerializeField] LaundryScript laundryScript;
    [SerializeField] Television television;
    [SerializeField] Piano piano;
    public bool firstdaytaskdone = false;

    private void Start()
    {
        objectPickUp = FindObjectOfType<ObjectPickUp>();
        lightSwitch = FindObjectOfType<NewLightSwitch>();
        pickUpPlace = FindObjectOfType<PickUpPlace>();
        laundryScript = FindObjectOfType<LaundryScript>();
        television = FindObjectOfType<Television>();
    }

    // Update is called once per frame
    void Update()
    {
        if (piano.playPianoDone && television.tvDone && lightSwitch.lightdone && pickUpPlace.eatdone && laundryScript.laundryTask)
        {
            firstdaytaskdone = true;
        }
    }
}
