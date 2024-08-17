using TMPro;
using UnityEngine;

public class SleepTriggerDay : MonoBehaviour
{
    public Camera sleepingCamera;
    public Animator cameraAnimator;
    [SerializeField] GameObject loadScene;
    [SerializeField] LoadingScene scene;
    [SerializeField] bool insidde = false;
    [SerializeField] TMP_Text sleepText;
    [SerializeField] Day1TaskTrack taskTrack;

    private void Start()
    {
        loadScene.SetActive(false);
    }
    private void Update()
    {
        if (insidde && Input.GetKeyDown(KeyCode.E))
        {
            NextDay();
            /* cameraAnimator.SetTrigger("SleepTrigger");
             sleepingCamera.gameObject.SetActive(true);*/

        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && taskTrack.alltaskdone)
        {
            sleepText.text = "End the Day";
            insidde = true;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && taskTrack.alltaskdone)
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
        loadScene.SetActive(true);
        scene.LoadScene("Day 2");


    }
}
