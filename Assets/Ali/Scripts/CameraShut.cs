using System.Collections;
using UnityEngine;

public class CameraShut : MonoBehaviour
{
    public Animator animator; 
    public string animationTriggerName = "CameraShut"; 
    public float delayBeforeAnimation; 
    public float animationDuration; 
    public string nextSceneName; 

    private bool animationStarted = false; 
    [SerializeField] LoadingScene scene;
    [SerializeField] GameObject loadScene;

    void Start()
    {
        Invoke("StartAnimation", delayBeforeAnimation);
        loadScene.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && !animationStarted)
        {
            SkipCutscene();
        }
    }

    void StartAnimation()
    {
        animator.SetTrigger(animationTriggerName);
        animationStarted = true;

        StartCoroutine(LoadNextSceneAfterAnimation());
    }

    void SkipCutscene()
    {
        animator.SetTrigger(animationTriggerName);
        animationStarted = true;

        StartCoroutine(LoadNextSceneAfterAnimation());
    }

    IEnumerator LoadNextSceneAfterAnimation()
    {
        yield return new WaitForSeconds(animationDuration);
        loadScene.SetActive(true);
        scene.LoadScene("Tutorial");
    }


}
