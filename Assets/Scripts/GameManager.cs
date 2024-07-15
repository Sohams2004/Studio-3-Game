using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] bool isPaused;
    [SerializeField] int pauseIndex;
    [SerializeField] GameObject pauseMenu;


    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pauseMenu.SetActive(false);
    }

    public void RestartGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pauseIndex % 2 is 0)
        {
            Debug.Log("Paused");
            pauseIndex++;
            PauseGame();
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && pauseIndex % 2 is not 0)
        {
            Debug.Log("Unpaused");
            pauseIndex++;
            ResumeGame();
        }
    }
}
