using System.Collections;
using UnityEngine;

public class PlayerAccident : MonoBehaviour
{
    [SerializeField] float timeToDieAfterCrash;
    [SerializeField] Rigidbody rb;
    [SerializeField] Movement movement;

    [SerializeField] bool isCrashed;

    [SerializeField] GameObject gameOverPAnel;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        movement = GetComponent<Movement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Car"))
        {
            rb.constraints = RigidbodyConstraints.None;
            movement.enabled = false;
            isCrashed = true;
        }
    }

    private void Update()
    {
        if (isCrashed)
        {
            StartCoroutine(GameOver());
        }
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(timeToDieAfterCrash);
        Time.timeScale = 0f;
        //ACTIVATE GAMEOVER PANEL HERE BELOW

    }
}
