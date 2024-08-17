using UnityEngine;

public class WaterBottle : MonoBehaviour
{
    public GameObject[] waterBottles; // Assign the water bottles in the Inspector
    public GameObject[] drinkTexts; // Assign the corresponding 3D Text objects in the Inspector
    public KeyCode drinkKey = KeyCode.F;
    public AudioSource audioSource; // Assign the AudioSource in the Inspector
    public AudioClip drinkingSound; // Assign the drinking sound effect in the Inspector
    [SerializeField] DamageScript damageScript;
    private GameObject currentBottle = null;
    private GameObject currentText = null;

    void Update()
    {
        // Check if the player is looking at an object with the tag "Bottle"
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        {
            if (hit.collider.CompareTag("Bottle"))
            {
                for (int i = 0; i < waterBottles.Length; i++)
                {
                    if (hit.collider.gameObject == waterBottles[i])
                    {

                        currentBottle = waterBottles[i];
                        currentText = drinkTexts[i];
                        currentText.SetActive(true);
                        break;
                    }
                }
            }
            else
            {
                if (currentText != null)
                {
                    currentText.SetActive(false);
                    currentText = null;
                }
                currentBottle = null;
            }
        }
        else
        {
            if (currentText != null)
            {
                currentText.SetActive(false);
                currentText = null;
            }
            currentBottle = null;
        }

        // Check if the drink key is pressed
        if (currentBottle != null && Input.GetKeyDown(drinkKey))
        {


            audioSource.PlayOneShot(drinkingSound); // Play the drinking sound effect
            if (currentText != null)
            {
                currentText.SetActive(false);
                currentText = null;
            }
            Destroy(currentBottle);
            currentBottle = null;

            damageScript.ThirstRecovered(100);
        }

    }
}
