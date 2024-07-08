using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliWalking : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private Rigidbody playerRb;
    [SerializeField] private AudioSource footSteps;
    [SerializeField] private Animator animator; // Reference to the Animator component

    private bool canMove = false; // Whether the player can move

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        // Play the wake-up animation
        animator.Play("WakeUp");

        // Disable movement initially
        canMove = false;

        // Start a coroutine to enable movement after the animation finishes
        StartCoroutine(EnableMovementAfterAnimation());
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            float inputx = Input.GetAxis("Horizontal");
            float inputz = Input.GetAxis("Vertical");

            Vector3 moveDirection = (transform.forward * inputz + transform.right * inputx) * movementSpeed * Time.deltaTime;
            playerRb.velocity = new Vector3(moveDirection.x, playerRb.velocity.y, moveDirection.z);
        }
        else
        {
            // Ensure player doesn't drift due to physics while animation is playing
            playerRb.velocity = Vector3.zero;
        }
    }

    private void Update()
    {
        if (canMove)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("Footsteps");
                footSteps.Play();
            }

            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
            {
                Debug.Log("Footsteps stopped");
                footSteps.Stop();
            }
        }
    }

    private IEnumerator EnableMovementAfterAnimation()
    {
        // Wait until the WakeUp animation is finished
        while (animator.GetCurrentAnimatorStateInfo(0).IsName("WakeUp") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            yield return null;
        }

        // Set the hasWokenUp parameter to true to transition to the Idle state
        animator.SetBool("hasWokenUp", true);

        // Optionally set player position and rotation after wake-up animation
        // Example: transform.position = new Vector3(0f, 0f, 0f);
        // Example: transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        // Enable movement
        canMove = true;
    }
}
