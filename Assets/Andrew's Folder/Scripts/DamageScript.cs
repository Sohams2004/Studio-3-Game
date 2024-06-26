using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageScript : MonoBehaviour
{

    public int maxHP = 200;
    public float currentHP;
    public float dmgOverTime = 10;
    [SerializeField] GameObject gameOverScreen;

    public BarLogic sanityBar;
    public BarLogic hungerBar;
    public BarLogic thirstBar;

    void Start()
    {
        Time.timeScale = 1f;
        gameOverScreen.SetActive(false);
        currentHP = maxHP;
        sanityBar.SetMaxValue(maxHP);
        hungerBar.SetMaxValue(maxHP);
        thirstBar.SetMaxValue(maxHP);
    }

    void Update()
    {
        currentHP -= dmgOverTime * Time.deltaTime;
        sanityBar.SetValue(currentHP);
        hungerBar.SetValue(currentHP);
        thirstBar.SetValue(currentHP);

        if (currentHP < 0)
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
        currentHP -= damage;
        sanityBar.SetValue(currentHP);
        hungerBar.SetValue(currentHP);
        thirstBar.SetValue(currentHP);
    }

    void GameOver()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
    }

}
