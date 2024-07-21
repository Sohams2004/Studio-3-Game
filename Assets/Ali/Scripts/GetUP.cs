using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetUP : MonoBehaviour
{

    public GameObject mainPlayer;
    public GameObject secondPlayer;
    public bool isSecondPlayerActive = false;

    // Start is called before the first frame update
    void Start()
    {
         mainPlayer.SetActive(true); // Ensure the main player is active at the start
        secondPlayer.SetActive(false); // Ensure the second player is inactive at the start
        isSecondPlayerActive = true;
    }



   void Update()
    {
        // If the second player is active and the player presses E, switch back to the main player
        if (isSecondPlayerActive && Input.GetKeyDown(KeyCode.F))
        {
            //Debug.Log("Switching back to main player");
            SwitchToMainPlayer();
        }
    }

     void SwitchToMainPlayer()
    {
        mainPlayer.SetActive(true);
        secondPlayer.SetActive(false);
        
        isSecondPlayerActive = false;
    }
}
