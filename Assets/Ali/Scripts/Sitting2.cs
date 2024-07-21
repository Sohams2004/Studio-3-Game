using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sitting2 : MonoBehaviour
{
     public GameObject mainPlayer;
    public GameObject secondPlayer;
    public bool isSecondPlayerActive = false;
    [SerializeField] GameObject GetUp;

    void Start()
    {
        mainPlayer.SetActive(true); // Ensure the main player is active at the start
        secondPlayer.SetActive(false); // Ensure the second player is inactive at the start
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the collider has the tag "Chair"
        if (other.CompareTag("Player"))
        {
            if (!isSecondPlayerActive)
            {
                //Debug.Log("Switching to second player");
                SwitchToSecondPlayer();
                GetUp.SetActive(true);

            }
        }
    }

    void SwitchToSecondPlayer()
    {
        mainPlayer.SetActive(false);
        secondPlayer.SetActive(true);
        isSecondPlayerActive = true;
    }

    
}
