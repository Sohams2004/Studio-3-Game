using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerAccident : MonoBehaviour
{
    [SerializeField] float timeToDieAfterCrash;
    [SerializeField] Rigidbody rb;
    [SerializeField] Movement movement;

    [SerializeField] bool isCrashed;

    [SerializeField] GameObject gameOverPAnel;

    [SerializeField] TextMeshProUGUI causeOfDeathText;

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

            causeOfDeathText.text = "You did not check the road!";
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
        gameOverPAnel.SetActive(true);
    }
}
