using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class ParentRoomKey : MonoBehaviour
{
    public TextMeshProUGUI KeyTask; //this to reference the text in inspector
    public bool keydone = false;
    //public TMP_Text promptText;
    private AudioSource audioSource;
    [SerializeField] GameObject keyCollected;
    [SerializeField] GameObject key;
    public bool pickedkey;
    private void Start()
    {
        pickedkey = false;
    }
    private async void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //promptText.text = "Press E to interact";
            if (Input.GetKeyDown(KeyCode.E))
            {

                key.SetActive(false);
                keyCollected.SetActive(true);
                keydone = true;
                pickedkey = true;
                await Task.Delay(1000);
                //promptText.text = string.Empty;

            }
        }
    }
    private async void OnTriggerStay(Collider other)
    {
        //promptText.text = "Press E to interact";
        if (Input.GetKeyDown(KeyCode.E))
        {



            key.SetActive(false);
            keyCollected.SetActive(true);
            KeyTask.text = "Key Collected";
            KeyTask.color = Color.green;
            keydone = true;
            pickedkey = true;
            await Task.Delay(1000);
            //promptText.text = string.Empty;
        }
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    promptText.text = string.Empty;
   // }
}
