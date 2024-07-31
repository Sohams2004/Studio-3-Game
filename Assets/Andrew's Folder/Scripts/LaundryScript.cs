using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LaundryScript : MonoBehaviour
{
    [SerializeField] Text pointText;
    [SerializeField] AudioClip limitReachedClip;
    private AudioSource audioSource;
    private int points = 20;

    public TextMeshProUGUI laundryTask;

    private void Awake()
    {
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
            if (points > 0)
            {
                Points--;
                if (points == 0)
                {
                    PlayLimitReachedClip();
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