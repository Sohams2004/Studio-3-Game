using UnityEngine;

public class Start : MonoBehaviour
{
    [SerializeField] GameObject loadScene;
    [SerializeField] LoadingScene scene;
    public void OnPlay()
    {
        loadScene.SetActive(true);
        scene.LoadScene("Cinematic");


    }
}
