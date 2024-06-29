using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public int maxHP = 200;
    public float sanity;
    public float hunger;
    public float thirst;

    public float sanityDecreaseRate = 1;
    public float hungerDecreaseRate = 1;
    public float thirstDecreaseRate = 1;

    [SerializeField] GameObject gameOverScreen;

    public BarLogic sanityBar;
    public BarLogic hungerBar;
    public BarLogic thirstBar;

    void Start()
    {
        Time.timeScale = 1f;
        gameOverScreen.SetActive(false);
        sanity = maxHP;
        hunger = maxHP;
        thirst = maxHP;

        sanityBar.SetMaxValue(maxHP);
        hungerBar.SetMaxValue(maxHP);
        thirstBar.SetMaxValue(maxHP);
    }

    void Update()
    {
        sanity -= sanityDecreaseRate * Time.deltaTime;
        hunger -= hungerDecreaseRate * Time.deltaTime;
        thirst -= thirstDecreaseRate * Time.deltaTime;

        sanityBar.SetValue(sanity);
        hungerBar.SetValue(hunger);
        thirstBar.SetValue(thirst);

        if (sanity < 0 || hunger < 0 || thirst < 0)
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
        sanity -= damage;
        sanityBar.SetValue(sanity);

        if (sanity < 0 || hunger < 0 || thirst < 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}