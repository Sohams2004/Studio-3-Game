using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DamageScript : MonoBehaviour
{
    public int maxHP = 1000;
    public int startingstat = 900;
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
    [SerializeField] Movement move;
    [SerializeField] PostProcessVolume postProcessingVolume;
    [SerializeField] Vignette vignette;

    [SerializeField] TextMeshProUGUI causeOfDeathText;
    void Start()
    {
        Time.timeScale = 1f;
        gameOverScreen.SetActive(false);
        sanity = maxHP;
        hunger = startingstat;
        thirst = startingstat;
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

        if (sanity <= 0)
        {
            GameOver();
            causeOfDeathText.text = "Jake went INSANE!";
        }

        if (hunger <= 0)
        {
            GameOver();
            causeOfDeathText.text = "Should have eaten enough";
        }

        if (thirst <= 0)
        {
            GameOver();
            causeOfDeathText.text = "Always stay hydrated";
        }


        if (vignette != null)
        {
            float vignetteIntensity = 1 - (sanity / 1000);
            vignette.intensity.value = vignetteIntensity;
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
    public void HungerRecovered(int heal)
    {
        hunger += heal;
        hungerBar.SetValue(sanity);
        if (hunger > startingstat)
        {
            move.movementSpeed = 1.5f;
        }
        else if (hunger < startingstat)
        {
            move.movementSpeed = 2f;
        }
        if (hunger > maxHP)
        {
            hunger = maxHP;
        }
    }
    public void ThirstRecovered(int heal)
    {
        thirst += heal;
        thirstBar.SetValue(sanity);
        if (thirst > startingstat)
        {
            postProcessingVolume.profile.TryGetSettings(out vignette);
        }
        else if (thirst < startingstat)
        {
            move.movementSpeed = 2f;
        }

        if (thirst > maxHP)
        {
            thirst = maxHP;
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
    public void HungerReduced(int damage)
    {
        hunger -= damage;
        hungerBar.SetValue(sanity);

        if (sanity <= 0 || hunger <= 0 || thirst <= 0)
        {
            GameOver();
        }
    }
    public void ThirstReduced(int damage)
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