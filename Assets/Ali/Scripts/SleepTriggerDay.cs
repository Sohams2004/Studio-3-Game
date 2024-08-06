using UnityEngine;

public class SleepTriggerDay : MonoBehaviour
{
    public Camera sleepingCamera;
    public Animator cameraAnimator;
    [SerializeField] GameObject loadScene;
    [SerializeField] LoadingScene scene;
    [SerializeField] bool insidde = false;
    private void Start()
    {
        loadScene.SetActive(false);
    }
    private void Update()
    {
        if (insidde && Input.GetKeyDown(KeyCode.E))
        {
            cameraAnimator.SetTrigger("SleepTrigger");

            sleepingCamera.gameObject.SetActive(true);
            loadScene.SetActive(true);
            scene.LoadScene("Day 2");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            insidde = true;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            insidde = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            insidde = false;
        }
    }
}
