using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageScript : MonoBehaviour
{

    public int maxSanity = 200;
    public float currentSanity;
    public float dmgOverTime = 10;

    public SanityBar sanityBar;

    void Start()
    {
        currentSanity = maxSanity;
        sanityBar.SetMaxValue(maxSanity);
    }

    void Update()
    {
        currentSanity -= dmgOverTime * Time.deltaTime;
        sanityBar.SetValue(currentSanity);

        if (currentSanity < 0)
        {
            GameOver();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hallucination"))
        {
            DamageReceived(50);
        }
    }

    void DamageReceived(int damage)
    {
        currentSanity -= damage;
        sanityBar.SetValue(currentSanity);
    }

    void GameOver()
    {
        SceneManager.LoadScene("Game Over");
    }

}
