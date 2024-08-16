using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LaundryScript : MonoBehaviour
{
    [SerializeField] Text pointText;
    [SerializeField] AudioClip limitReachedClip;
    private AudioSource audioSource;
    public int points = 5;
    public bool laundry = false;
    [SerializeField] Animator machineActivate;

    [SerializeField] GameObject laundryFull;
    [SerializeField] GameObject laundryFull2;
    [SerializeField] GameObject laundryDone;

    public TextMeshProUGUI laundryTask;

    HotBar hotBar;
    ObjectPickUp objectPickUp;

    private void Awake()
    {
        objectPickUp = FindObjectOfType<ObjectPickUp>();

        laundryFull.SetActive(false);
        laundryFull2.SetActive(false);
        laundryDone.SetActive(false);
        UpdateUI();
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        hotBar = FindObjectOfType<HotBar>();
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
                machineActivate.Play("Door Closing Animation");
                machineActivate.Play("Laundry Activate");

                PlayLimitReachedClip();
                Points--;

                if (points == 5)
                {
                    laundryFull.SetActive(true);

                }

                if (points == 2)
                {
                    laundryFull2.SetActive(true);
                    laundryFull.SetActive(false);

                }

                if (points == 0)
                {

                    laundryDone.SetActive(true);
                    laundryFull2.SetActive(false);
                    machineActivate.Play("Door Opening Animation");
                    audioSource.Stop();
                    laundryTask.text = "Clothes washed";
                    laundryTask.color = Color.green;
                    laundry = true;
                }
            }
            objectPickUp.clothCount -= 1;
            objectPickUp.clothCountText.text = objectPickUp.clothCount.ToString();
            hotBar.currentObject.SetActive(false);
            hotBar.currentObject.transform.parent = null;
            hotBar.items.Remove(hotBar.currentObject);

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