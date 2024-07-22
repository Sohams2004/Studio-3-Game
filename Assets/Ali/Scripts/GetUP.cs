/*using UnityEngine;

public class GetUP : MonoBehaviour
{

    [SerializeField] Sitting2 sitting2;

    // Start is called before the first frame update


    void Update()
    {
        // If the second player is active and the player presses E, switch back to the main player
        if (sitting2.isSecondPlayerActive && Input.GetKeyDown(KeyCode.F))
        {
            //Debug.Log("Switching back to main player");
            SwitchToMainPlayer();
        }
    }

    void SwitchToMainPlayer()
    {
        sitting2.mainPlayer.SetActive(true);
        sitting2.secondPlayer.SetActive(false);

        sitting2.isSecondPlayerActive = false;
    }
}
*/