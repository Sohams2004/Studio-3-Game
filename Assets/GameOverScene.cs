using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
    public GameObject gameOverUI;

    public float waitTime = 1.5f;

    void Awake()
    {
        gameOverUI.SetActive(false);
    }

    void Start()
    {
        StartCoroutine(GameOverUIAfterDelay());
    }

    private System.Collections.IEnumerator GameOverUIAfterDelay()
    {

        yield return new WaitForSeconds(waitTime);

        if (gameOverUI != null)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            gameOverUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu Layout");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
