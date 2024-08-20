using TMPro;
using UnityEngine;

public class SleepTrigger : MonoBehaviour
{
    public Camera sleepingCamera;
    public Animator cameraAnimator;
    [SerializeField] GameObject loadScene;
    [SerializeField] LoadingScene scene;
    [SerializeField] bool insidde = false;
    [SerializeField] TMP_Text sleepText;
    [SerializeField] Day2TaskTrack taskTrack1;
    private void Start()
    {
        loadScene.SetActive(false);
    }
    private void Update()
    {
        if (insidde && Input.GetKey(KeyCode.Mouse0))
        {
            NextDay();

        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && taskTrack1.firstdaytaskdone)
        {
            sleepText.text = "End the Day";
            insidde = true;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && taskTrack1.firstdaytaskdone)
        {
            sleepText.text = "End the Day";
            insidde = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sleepText.text = string.Empty;
            insidde = false;
        }
    }
    void NextDay()
    {
        scene.LoadScene("Day 1");
        loadScene.SetActive(true);
    }
}
