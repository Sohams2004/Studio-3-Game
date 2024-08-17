using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadingScene : MonoBehaviour
{
    public Slider loadingBar;
    public TMP_Text loadingText;

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadAsync(sceneName));
    }
    IEnumerator LoadAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadingBar.value = progress;
            loadingText.text = (progress * 100f).ToString("F0") + "%";
            yield return null;
        }
    }
}
