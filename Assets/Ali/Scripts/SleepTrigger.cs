using System.Threading.Tasks;
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
    private async void Update()
    {
        if (insidde && Input.GetKey(KeyCode.E))
        {
            cameraAnimator.SetTrigger("SleepTrigger");

            sleepingCamera.gameObject.SetActive(true);
            await Task.Delay(1000);
            loadScene.SetActive(true);
            scene.LoadScene("Day 1");
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
}
