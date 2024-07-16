using System.Threading.Tasks;
using UnityEngine;
using TMPro;

public class AntipsychoticsDrug : MonoBehaviour
{
    public TextMeshProUGUI MedicineTask;

    [SerializeField] DamageScript damageScript;
    private bool playerInRange = false;


    // Update is called once per frame
    async void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            await Task.Delay(1000);
            damageScript.SanityRecovered(100);

             MedicineTask.text = "Took Medicine";
             MedicineTask.color = Color.green;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        playerInRange = false;
    }
}
