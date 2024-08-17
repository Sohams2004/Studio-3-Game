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
    [SerializeField] TextMeshProUGUI amPMText;
    [SerializeField] TextMeshProUGUI colon;

    [SerializeField] bool isPM;


    private void Start()
    {
        loadScene.SetActive(false);
        secondsText.color = Color.green;
        minutesText.color = Color.green;
        colon.color = Color.green;
        amPMText.color = Color.green;
    }

    void Timer()
    {
        seconds += Time.deltaTime * 3f;

        if (seconds >= 59)
        {
            seconds = 00;
            minutes++;
        }

        if (minutes > 12)
        {
            minutes = 1;
        }

        if (minutes >= 12)
        {
            isPM = true;
            amPMText.text = "pm";
        }

        if (seconds <= 9)
        {
            secondsText.text = string.Format("0" + Mathf.RoundToInt(seconds));
        }
        else if (seconds >= 9)
        {
            secondsText.text = string.Format("" + Mathf.RoundToInt(seconds));
        }

        if (minutes < 10)
        {
            minutesText.text = string.Format("0" + minutes);
        }

        else if (minutes >= 10)
        {
            minutesText.text = string.Format("" + minutes);
        }

        if (isPM)
        {
            if (minutes == 7)
            {
                secondsText.color = Color.red;
                minutesText.color = Color.red;
                colon.color = Color.red;
                amPMText.color = Color.red;
            }

            if (minutes == 8)
            {

                seconds += Time.deltaTime * 0;
            }
        }
    }

    void MoveToNextScene()
    {
        if (minutes == 8 && isPM)
        {
            scene.LoadScene("Good End Scene");
            loadScene.SetActive(true);
        }


    }

    private void Update()
    {
        Timer();
        MoveToNextScene();
    }
}
