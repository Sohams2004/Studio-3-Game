using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LaundryScript : MonoBehaviour
{
    [SerializeField] Text pointText;
    [SerializeField] AudioClip limitReachedClip;
    private AudioSource audioSource;
    private int points = 10;

    [SerializeField] Animator machineActivate;

    [SerializeField] GameObject laundryFull;
    [SerializeField] GameObject laundryFull2;
    [SerializeField] GameObject laundryDone;

    public TextMeshProUGUI laundryTask;

    private void Awake()
    {
        laundryFull.SetActive(false);
        laundryFull2.SetActive(false);
        laundryDone.SetActive(false);
        UpdateUI();
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public int Points
    {
        get
        {
            return points;
        }
        set
        {
            points = value;
            UpdateUI();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Clothing"))
        {
            machineActivate.Play("Door Closing Animation");
            machineActivate.Play("Laundry Activate");

            if (points > 0)
            {
                Points--;

                if (points == 10)
                {
                    laundryFull.SetActive(true);
                }

                if (points == 5)
                {
                    laundryFull2.SetActive(true);
                    laundryFull.SetActive(false);
                }

                if (points == 0)
                {
                    PlayLimitReachedClip();
                    laundryDone.SetActive(true);
                    laundryFull2.SetActive(false);
                    machineActivate.Play("Door Opening Animation");
                    laundryTask.text = "Clothes washed";
                    laundryTask.color = Color.green;
                }
            }
            Destroy(other.gameObject);
        }
    }

    private void UpdateUI()
    {
        if (pointText != null)
        {
            pointText.text = "Laundry: " + points.ToString();
        }
    }

    private void PlayLimitReachedClip()
    {
        if (audioSource != null && limitReachedClip != null)
        {
            audioSource.PlayOneShot(limitReachedClip);
        }
    }
}