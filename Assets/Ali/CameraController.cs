using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera WakeUpCamera;
    public Camera playerCamera;
    [SerializeField] DamageScript damageScript;
    void Start()
    {
        damageScript.loadScene.SetActive(false);
        damageScript = FindObjectOfType<DamageScript>();
        damageScript.hunger = damageScript.startinghunger;
        damageScript.thirst = damageScript.startingthirst;
        WakeUpCamera.gameObject.SetActive(true);
        playerCamera.gameObject.SetActive(false);
    }

    public void SwitchToPlayerCamera()
    {

        WakeUpCamera.gameObject.SetActive(false);
        playerCamera.gameObject.SetActive(true);
    }
}
