using UnityEngine;

public class HallWay : MonoBehaviour
{

    public GameObject hallway;
    public GameObject finalDoor;  
    public GameObject monster;
    public GameObject invisibleWall;  
    public Transform monsterStartPosition;
    public AudioSource scarySound;
    public AudioSource scarySound2;
    public AudioSource scarySound3;
    public float monsterFollowDelay = 5f;  
    public Transform player;
    public Transform playerResetPosition;
    [SerializeField] GameObject door;
    [SerializeField] GameObject littleGirl;
    [SerializeField] GameObject fence;

    private bool monsterActive = false;
    private bool invisibleWallEnabled = false;  

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            RenderSettings.fog = true;
            if (CompareTag("SecondTrigger") && !monsterActive)
            {
                
                hallway.SetActive(true);
                finalDoor.SetActive(true);
                littleGirl.SetActive(false);
                fence.SetActive(false);
                invisibleWall.SetActive(false);
                
                Invoke(nameof(ActivateMonster), 2f);  
            }
            else if (CompareTag("ThirdTrigger") && !invisibleWallEnabled)
            {
                door.SetActive(false);
                invisibleWall.SetActive(true);
                invisibleWallEnabled = true;
                /* // 
                 if (invisibleWall != null)
                 {

                     // Set flag to true so it won't be enabled again
                 }*/
            }
            else if (CompareTag("FinalTrigger"))
            {
                invisibleWall.SetActive(false);
                littleGirl.SetActive(true);
                fence.SetActive(true);
                door.SetActive(true);
                HandleFinalTrigger();
            }
        }
    }

    void ActivateMonster()
    {
        monster.transform.position = monsterStartPosition.position;
        monster.SetActive(true);
        scarySound.Play();
        scarySound2.Play();
        scarySound3.Play();
        monsterActive = true;

        
        Invoke(nameof(StartMonsterFollow), monsterFollowDelay);
    }

    void StartMonsterFollow()
    {
        
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
        
        if (hallway != null) hallway.SetActive(false);
        if (finalDoor != null) finalDoor.SetActive(false);
        if (monster != null) monster.SetActive(false);

        if (invisibleWall != null)
        {
            invisibleWall.SetActive(false);
        }

        ResetPlayerPosition();
    }

    void ResetPlayerPosition()
    {
        if (playerResetPosition != null)
        {
            player.position = playerResetPosition.position;
            player.rotation = playerResetPosition.rotation;
        }
        
    }
}
