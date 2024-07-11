using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public GameObject playerObject; // Assign your player object in the Inspector

    void Start()
    {
        // Disable the player object initially
        playerObject.SetActive(false);
    }

    public void OnAnimationFinished()
    {
        // This method is called when your animation finishes playing
        playerObject.SetActive(true);
    }
}
