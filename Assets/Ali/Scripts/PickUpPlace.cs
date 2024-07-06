using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickUpPlace : MonoBehaviour
{
 private GameObject pickedObject;
    public float pickUpRange = 2.0f;
    public float holdDistance = 0.7f;
    public LayerMask pickUpLayer;

    private GameObject orangeJuice;
    private GameObject panWithFriedEgg;

    public TextMeshPro drinkText;
    public TextMeshPro eatText;
    public AudioSource drinkSound;
    public AudioSource eatSound;

    public TextMeshProUGUI DrinkTask; // Reference to your Drink Juice UI TextMeshPro object
public TextMeshProUGUI EatTask;   // Reference to your Eat Egg UI TextMeshPro object

    private bool isLookingAtOrangeJuice = false;
    private bool isLookingAtPanWithFriedEgg = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            if (pickedObject == null)
            {
                PickUp();
            }
            else
            {
                Place();
            }
        }

        if (pickedObject != null)
        {
            HoldObject();
        }

        CheckForInteraction();

        if (isLookingAtOrangeJuice && Input.GetKeyDown(KeyCode.F))
        {
            DrinkOrangeJuice();
        }

        if (isLookingAtPanWithFriedEgg && Input.GetKeyDown(KeyCode.F))
        {
            EatPanWithFriedEgg();
        }
    }

    void PickUp()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, pickUpRange, pickUpLayer))
        {
            if (hit.collider.gameObject.GetComponent<Rigidbody>())
            {
                pickedObject = hit.collider.gameObject;
                pickedObject.GetComponent<Rigidbody>().useGravity = false;
                pickedObject.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }

    void Place()
    {
        pickedObject.GetComponent<Rigidbody>().useGravity = true;
        pickedObject.GetComponent<Rigidbody>().isKinematic = false;
        pickedObject = null;
    }

    void HoldObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        pickedObject.transform.position = ray.GetPoint(holdDistance);
    }

    void CheckForInteraction()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, pickUpRange, pickUpLayer))
        {
            if (hit.collider.gameObject.CompareTag("OrangeJuice"))
            {
                orangeJuice = hit.collider.gameObject;
                drinkText.transform.position = orangeJuice.transform.position + new Vector3(0, 1, 0);
                drinkText.gameObject.SetActive(true);
                isLookingAtOrangeJuice = true;
                //Debug.Log("Looking at Orange Juice");
            }
            else if (hit.collider.gameObject.CompareTag("PanWithFriedEgg"))
            {
                panWithFriedEgg = hit.collider.gameObject;
                eatText.transform.position = panWithFriedEgg.transform.position + new Vector3(0, 1, 0);
                eatText.gameObject.SetActive(true);
                isLookingAtPanWithFriedEgg = true;
                //Debug.Log("Looking at Pan With Fried Egg");
            }
            else
            {
                drinkText.gameObject.SetActive(false);
                eatText.gameObject.SetActive(false);
                isLookingAtOrangeJuice = false;
                isLookingAtPanWithFriedEgg = false;
            }
        }
        else
        {
            drinkText.gameObject.SetActive(false);
            eatText.gameObject.SetActive(false);
            isLookingAtOrangeJuice = false;
            isLookingAtPanWithFriedEgg = false;
        }
    }

    void DrinkOrangeJuice()
    {
        //Debug.Log("Drinking Orange Juice");
        Destroy(orangeJuice);
        drinkText.gameObject.SetActive(false);
        drinkSound.Play();
        isLookingAtOrangeJuice = false;

        DrinkTask.text = "Drink Juice Done"; // Update TextMeshPro text
        DrinkTask.color = Color.green;

        
    }

    void EatPanWithFriedEgg()
    {
        //Debug.Log("Eating Pan With Fried Egg");
        Destroy(panWithFriedEgg);
        eatText.gameObject.SetActive(false);
        eatSound.Play();
        isLookingAtPanWithFriedEgg = false;

        EatTask.text = "Eat Egg Done";
        EatTask.color = Color.green;

        
    }

   
}
