using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DamageScript : MonoBehaviour
{
    public int maxHP = 1000;
    public int startingsanity;
    public int startingstat;
    public int startinghunger = 900;
    public int startingthirst = 900;
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
    public GameObject loadScene;
    public LoadingScene scene;

    void Start()
    {
        Time.timeScale = 1f;
        gameOverScreen.SetActive(false);
        sanity = startingsanity;
        hunger = startinghunger;
        thirst = startingthirst;
        hasInteracted = false;
        sanityBar.SetMaxValue(maxHP);
        hungerBar.SetMaxValue(maxHP);
        thirstBar.SetMaxValue(maxHP);


    }

    void Update()
    {
        OverDrank();
        OverEat();


        sanity -= sanityDecreaseRate * Time.deltaTime;
        hunger -= hungerDecreaseRate * Time.deltaTime;
        thirst -= thirstDecreaseRate * Time.deltaTime;

        sanityBar.SetValue(sanity);
        hungerBar.SetValue(hunger);
        thirstBar.SetValue(thirst);

        if (sanity <= 0)
        {
            GameOverSanity();
        }

        if (hunger <= 0)
        {
            GameOver();
            causeOfDeathText.text = "Should have eaten something";
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

        if (hunger > maxHP)
        {
            hunger = maxHP;
        }
    }
    public void ThirstRecovered(int heal)
    {
        thirst += heal;
        thirstBar.SetValue(sanity);


        if (thirst > maxHP)
        {
            thirst = maxHP;
        }
    }
    public async void DamageReceived(int damage)
    {
        sanity -= damage;

        sanityBar.SetValue(sanity);
        await Task.Delay(2000);

    }
    public void HungerReduced(int damage)
    {
        hunger -= damage;
        hungerBar.SetValue(sanity);

    }
    public void ThirstReduced(int damage)
    {
        thirst -= damage;
        thirstBar.SetValue(sanity);

    }

    void GameOver()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;

    }
    void GameOverSanity()
    {
        scene.LoadScene("Game Over");
        loadScene.SetActive(true);
        SanityRecovered(100);

    }
    void OverEat()
    {
        if (hunger > startingstat)
        {
            move.walkSpeed = 1f;
        }
        else if (hunger <= startingstat)
        {
            move.walkSpeed = 2f;
        }
    }
    void OverDrank()
    {
        if (thirst > startingthirst)
        {
            move.sprintSpeed = 2f;
        }
        else if (thirst < startingthirst)
        {
            move.sprintSpeed = 3f;
        }

    }
}