using UnityEngine;
using UnityEngine.UI;

public class LaundryScript : MonoBehaviour
{
    public GameObject laundryCountText;
    public AudioClip limitReachedClip;
    private AudioSource audioSource;
    private Text counterText;
    private int count = 0;
    private int limit = 20;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (laundryCountText != null)
        {
            counterText = laundryCountText.GetComponent<Text>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Clothing"))
        {
            count++;
            UpdateCounterText();
            if (count == limit)
            {
                PlayLimitReachedClip();
            }
        }
    }

    private void UpdateCounterText()
    {
        if (counterText != null)
        {
            counterText.text = "Laundry: " + count.ToString() + " / " + limit.ToString();
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