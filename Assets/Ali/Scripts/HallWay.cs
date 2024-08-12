using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HallWay : MonoBehaviour
{
      
   public GameObject hallway;
    public GameObject finalDoor;  // The final door to be disabled
    public GameObject monster;
    public Transform monsterStartPosition;
    public AudioSource scarySound;
    public float monsterFollowDelay = 3f;  // Delay before monster starts following
    public Transform player;
    public Transform playerResetPosition;  // The position to reset the player to
    public string newSceneName;  // The name of the scene to load

    private bool monsterActive = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (CompareTag("SecondTrigger") && !monsterActive)
            {
                // Enable the hallway when the second collider is triggered
                hallway.SetActive(true);

                // Activate the monster after a delay
                Invoke(nameof(ActivateMonster), 2f);  // 2-second delay before activating the monster
            }
            else if (CompareTag("FinalTrigger"))
            {
                // Perform actions when the final trigger is hit
                HandleFinalTrigger();
            }
        }
    }

    void ActivateMonster()
    {
        monster.transform.position = monsterStartPosition.position;
        monster.SetActive(true);
        scarySound.Play();
        monsterActive = true;

        // Start the monster follow sequence after the sound delay
        Invoke(nameof(StartMonsterFollow), monsterFollowDelay);
    }

    void StartMonsterFollow()
    {
        monster.GetComponent<MonsterAI>().StartFollowing(player);
    }

    void HandleFinalTrigger()
    {
        // Disable hallway, final door, and monster
        if (hallway != null) hallway.SetActive(false);
        if (finalDoor != null) finalDoor.SetActive(false);
        if (monster != null) monster.SetActive(false);

        // Reset the player's position
        ResetPlayerPosition();

        // Load the new scene
        //LoadNewScene();
    }

    void ResetPlayerPosition()
    {
        if (playerResetPosition != null)
        {
            player.position = playerResetPosition.position;
            // Optionally reset the player's rotation if needed
            player.rotation = playerResetPosition.rotation;
        }
        else
        {
            Debug.LogError("Player reset position is not assigned.");
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
