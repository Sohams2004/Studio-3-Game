using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed;
    public float sprintSpeed = 4;
    public float walkSpeed = 2;
    [SerializeField] private Rigidbody playerRb;

    [SerializeField] AudioSource footSteps;


    private void Start()
    {
        movementSpeed = walkSpeed;
        playerRb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        float inputx = Input.GetAxis("Horizontal");
        float inputz = Input.GetAxis("Vertical");

        Vector3 moveDirection = (transform.forward * inputz + transform.right * inputx) * movementSpeed * 100 * Time.deltaTime;
        playerRb.velocity = new(moveDirection.x, playerRb.velocity.y, moveDirection.z);



    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed += sprintSpeed;

        }

        else
        {
            movementSpeed = walkSpeed;

        }
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
