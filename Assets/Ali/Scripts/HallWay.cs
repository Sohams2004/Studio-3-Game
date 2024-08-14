using UnityEngine;

public class HallWay : MonoBehaviour
{

    public GameObject hallway;
    public GameObject finalDoor;  // The final door to be disabled
    public GameObject monster;
    public GameObject invisibleWall;  // The invisible wall to be enabled/disabled
    public Transform monsterStartPosition;
    public AudioSource scarySound;
    public float monsterFollowDelay = 5f;  // Delay before monster starts following
    public Transform player;
    public Transform playerResetPosition;  // The position to reset the player to

    private bool monsterActive = false;
    private bool invisibleWallEnabled = false;  // Flag to track if the invisible wall has been enabled

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RenderSettings.fog = true;
            if (CompareTag("SecondTrigger") && !monsterActive)
            {
                // Enable the hallway and final door when the second collider is triggered
                hallway.SetActive(true);
                finalDoor.SetActive(true);

                // Activate the monster after a delay
                Invoke(nameof(ActivateMonster), 2f);  // 2-second delay before activating the monster
            }
            else if (CompareTag("ThirdTrigger") && !invisibleWallEnabled)
            {
                // Enable the invisible wall when the third collider is triggered
                if (invisibleWall != null)
                {
                    invisibleWall.SetActive(true);
                    invisibleWallEnabled = true;  // Set flag to true so it won't be enabled again
                }
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
        // Ensure the MonsterAI component is present and set the player
        MonsterAI monsterAI = monster.GetComponent<MonsterAI>();
        if (monsterAI != null)
        {
            monsterAI.SetPlayer(player);
        }
        else
        {
            Debug.LogError("MonsterAI component not found on monster.");
        }
    }

    void HandleFinalTrigger()
    {
        // Disable hallway, final door, and monster
        if (hallway != null) hallway.SetActive(false);
        if (finalDoor != null) finalDoor.SetActive(false);
        if (monster != null) monster.SetActive(false);

        // Disable the invisible wall
        if (invisibleWall != null)
        {
            invisibleWall.SetActive(false);
        }

        // Reset the player's position
        ResetPlayerPosition();
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
}
