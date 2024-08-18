using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class FrontDoorKey : MonoBehaviour
{
    public TextMeshProUGUI KeyTask; //this to reference the text in inspector
    public bool key2done = false;
    //public TMP_Text promptText;
    private AudioSource audioSource;
    [SerializeField] GameObject keyCollected;
    [SerializeField] GameObject key;
    public bool pickedkeysittingroom;
    private void Start()
    {
        pickedkeysittingroom = false;
    }
    private async void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //promptText.text = "Press E to interact";
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {

                key.SetActive(false);
                key2done = true;
                keyCollected.SetActive(true);

                pickedkeysittingroom = true;


            }
        }
    }
    private async void OnTriggerStay(Collider other)
    {
        //promptText.text = "Press E to interact";
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {



            key.SetActive(false);
            keyCollected.SetActive(true);
            KeyTask.text = "Key Collected";
            KeyTask.color = Color.green;
            key2done = true;
            pickedkeysittingroom = true;
            await Task.Delay(1000);
            //promptText.text = string.Empty;
        }
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    promptText.text = string.Empty;
    // }
}
