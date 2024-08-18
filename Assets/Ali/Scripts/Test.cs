using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    public string newSceneName;  

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            Debug.Log("FinalTrigger activated. Loading new scene.");
            LoadNewScene();
        }
    }

    void LoadNewScene()
    {
        if (!string.IsNullOrEmpty(newSceneName))
        {
            Debug.Log($"Loading scene: {newSceneName}");
            SceneManager.LoadScene(newSceneName);
        }
        else
        {
            Debug.LogError("New scene name is not assigned.");
        }
    }
}
