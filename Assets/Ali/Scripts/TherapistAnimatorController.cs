using UnityEngine;

public class TherapistAnimatorController : MonoBehaviour
{
    public float delayBeforeStanding = 5f; // Time in seconds before the therapist stands up
    private Animator animator;
    private float timer;

    void Start()
    {

        animator = GetComponent<Animator>();
        timer = 0f;
    }

    void Update()
    {


        timer += Time.deltaTime;
        if (timer >= delayBeforeStanding)
        {
            animator.SetTrigger("StandUp");
        }
    }
}
