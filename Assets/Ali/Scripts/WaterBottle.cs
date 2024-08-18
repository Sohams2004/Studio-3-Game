using UnityEngine;

public class WaterBottle : MonoBehaviour
{
    public GameObject[] waterBottles; 
    public GameObject[] drinkTexts; 
    public KeyCode drinkKey = KeyCode.F;
    public AudioSource audioSource; 
    public AudioClip drinkingSound; 
    [SerializeField] DamageScript damageScript;
    private GameObject currentBottle = null;
    private GameObject currentText = null;

    void Update()
    {
        
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

        
        if (currentBottle != null && Input.GetKeyDown(drinkKey))
        {


            audioSource.PlayOneShot(drinkingSound); 
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
