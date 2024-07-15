using System.Threading.Tasks;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public int maxHP = 200;
    public float sanity;
    public float hunger;
    public float thirst;

    public float sanityDecreaseRate = 2;
    public float hungerDecreaseRate = 5;
    public float thirstDecreaseRate = 7;

    [SerializeField] GameObject gameOverScreen;

    public BarLogic sanityBar;
    public BarLogic hungerBar;
    public BarLogic thirstBar;

    [SerializeField] bool hasInteracted;
    void Start()
    {
        Time.timeScale = 1f;
        gameOverScreen.SetActive(false);
        sanity = maxHP;
        hunger = maxHP;
        thirst = maxHP;
        hasInteracted = false;
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

        if (sanity <= 0 || hunger <= 0 || thirst <= 0)
        {
            GameOver();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hallucination") && !hasInteracted)
        {
            DamageReceived(30);
            hasInteracted = true;
        }

    }

    public void SanityRecovered(int heal)
    {
        sanity += heal;
        sanityBar.SetValue(sanity);
        if (sanity > maxHP)
        {
            sanity = maxHP;
        }

    }
    async void DamageReceived(int damage)
    {
        sanity -= damage;

        sanityBar.SetValue(sanity);
        await Task.Delay(2000);
        if (sanity <= 0 || hunger <= 0 || thirst <= 0)
        {
            GameOver();
        }
    }
    public async void HungerReduced(int damage)
    {
        hunger -= damage;
        hungerBar.SetValue(sanity);

        if (sanity <= 0 || hunger <= 0 || thirst <= 0)
        {
            GameOver();
        }
    }
    public async void HydrasionReduced(int damage)
    {
        thirst -= damage;
        thirstBar.SetValue(sanity);

        if (sanity <= 0 || hunger <= 0 || thirst <= 0)
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