using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HallWay : MonoBehaviour
{
     public GameObject hallway;
    public GameObject invisibleWall;
    public GameObject monster;
    public Transform monsterStartPosition;
    public Transform playerResetPosition;
    public AudioSource scarySound;
    public float monsterFollowDelay = 3f;
    public Transform player;

    private bool hallwayEnabled = false;
    private bool monsterActive = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (CompareTag("SecondTrigger") && !hallwayEnabled)
            {
                Debug.Log("SecondCollider: Enabling hallway.");
                hallway.SetActive(true);
                hallwayEnabled = true;
            }
            else if (CompareTag("ThirdTrigger") && hallwayEnabled && !monsterActive)
            {
                Debug.Log("ThirdCollider: Enabling invisible wall and monster.");
                invisibleWall.SetActive(true);

                monster.transform.position = monsterStartPosition.position;
                monster.SetActive(true);
                scarySound.Play();
                monsterActive = true;

                Invoke(nameof(StartMonsterFollow), monsterFollowDelay);
            }
            else if (CompareTag("FinalTrigger") && monsterActive)
            {
                Debug.Log("FinalCollider: Disabling hallway and resetting player.");
                hallway.SetActive(false);
                monster.SetActive(false);
                invisibleWall.SetActive(false);
                player.position = playerResetPosition.position;
            }
        }
    }

    void StartMonsterFollow()
    {
        Debug.Log("Monster starts following the player.");
        monster.GetComponent<MonsterAI>().StartFollowing(player);
    }
}
