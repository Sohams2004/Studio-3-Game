using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    public string newSceneName;  // The name of the scene to load

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Debug statement to check if FinalTrigger logic is reached
            Debug.Log("FinalTrigger activated. Loading new scene.");
            LoadNewScene();
        }
    }

    void LoadNewScene()
    {
        if (!string.IsNullOrEmpty(newSceneName))
        {
            // Debug statement to check scene name before loading
            Debug.Log($"Loading scene: {newSceneName}");
            SceneManager.LoadScene(newSceneName);
        }
        else
        {
            Debug.LogError("New scene name is not assigned.");
        }
    }
}
