using UnityEngine;

public class SleepTriggerDay2 : MonoBehaviour
{
    public Camera sleepingCamera;
    public Animator cameraAnimator;
    [SerializeField] GameObject loadScene;
    [SerializeField] LoadingScene scene;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            cameraAnimator.SetTrigger("SleepTrigger");

            sleepingCamera.gameObject.SetActive(true);
            loadScene.SetActive(true);
            scene.LoadScene("Day 2");
        }
    }
}
