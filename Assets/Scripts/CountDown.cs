using TMPro;
//using UnityEditor.SearchService;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    [SerializeField] float seconds = 60;
    [SerializeField] float minutes;
    [SerializeField] GameObject loadScene;
    [SerializeField] LoadingScene scene;
    [SerializeField] TextMeshProUGUI secondsText;
    [SerializeField] TextMeshProUGUI minutesText;

    void Timer()
    {
        seconds -= Time.deltaTime;

        if (seconds <= 0)
        {
            seconds = 60;
            minutes--;
        }

        secondsText.text = string.Format("" + Mathf.RoundToInt(seconds));
        minutesText.text = string.Format(minutes + " :");
    }

    void MoveToNextScene()
    {
        if (minutes <= 0)
        {
            loadScene.SetActive(true);
            scene.LoadScene("Cinematic");

        }
    }

    private void Update()
    {
        Timer();
        MoveToNextScene();
    }
}
