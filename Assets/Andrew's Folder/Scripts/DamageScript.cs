using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public int maxHP = 200;
    public float currentHP;
    public float sanity;
    public float hunger;
    public float thirst;

    public float dmgOverTime = 10;
    public float sanityDecreaseRate = 2;
    public float hungerDecreaseRate = 5;
    public float thirstDecreaseRate = 7;

    [SerializeField] GameObject gameOverScreen;

    public BarLogic sanityBar;
    public BarLogic hungerBar;
    public BarLogic thirstBar;

    void Start()
    {
        Time.timeScale = 1f;
        gameOverScreen.SetActive(false);
        currentHP = maxHP;
        sanity = maxHP;
        hunger = maxHP;
        thirst = maxHP;

        sanityBar.SetMaxValue(maxHP);
        hungerBar.SetMaxValue(maxHP);
        thirstBar.SetMaxValue(maxHP);
    }

    void Update()
    {
        currentHP -= dmgOverTime * Time.deltaTime;
        sanity -= sanityDecreaseRate * Time.deltaTime;
        hunger -= hungerDecreaseRate * Time.deltaTime;
        thirst -= thirstDecreaseRate * Time.deltaTime;

        sanityBar.SetValue(sanity);
        hungerBar.SetValue(hunger);
        thirstBar.SetValue(thirst);

        if (currentHP < 0 || sanity < 0 || hunger < 0 || thirst < 0)
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
        currentHP -= damage;
        sanityBar.SetValue(sanity);

        if (currentHP < 0 || sanity < 0 || hunger < 0 || thirst < 0)
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