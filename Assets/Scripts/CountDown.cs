using System.Collections;
using System.Collections.Generic;
using TMPro;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour
{
    [SerializeField] float seconds = 60;
    [SerializeField] float minutes;

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
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.buildIndex + 1);
        }
    }

    private void Update()
    {
        Timer();
        MoveToNextScene();
    }
}
