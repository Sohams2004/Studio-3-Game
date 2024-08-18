using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class AntipsychoticsDrug : MonoBehaviour
{
    public TextMeshProUGUI MedicineTask;
    public bool medicinedone = false;
    [SerializeField] DamageScript damageScript;
    private bool playerInRange = false;
    public bool medwithnofood = false;

    // Update is called once per frame
    async void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            await Task.Delay(1000);
            damageScript.SanityRecovered(100);
            medicinedone = true;
            MedicineTask.text = "Took Medicine";
            MedicineTask.color = Color.green;

            medwithnofood = true;
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
