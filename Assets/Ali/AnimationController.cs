using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public GameObject playerObject;

    void Start()
    {

        playerObject.SetActive(false);
    }

    public void OnAnimationFinished()
    {

        playerObject.SetActive(true);
    }
}
