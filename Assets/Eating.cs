using System.Threading.Tasks;
using UnityEngine;
public class Eating : MonoBehaviour
{

    [SerializeField] DamageScript damageScript;
    private bool playerInRange = false;


    // Update is called once per frame
    async void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            await Task.Delay(1000);
            damageScript.HungerRecovered(100);
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

