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

    public TextMeshProUGUI eatEggTextMeshPro; // Reference to the TextMeshProUGUI for "Eat Egg"

    private bool hasEatenEgg = false; // Flag to track if the egg has been eaten

    public AudioSource drinkSound;
    public AudioSource eatSound;

    private bool isLookingAtOrangeJuice = false;
    private bool isLookingAtPanWithFriedEgg = false;

    void Start()
    {
        // Ensure "Eat Egg" text is correctly initialized and displayed
        if (eatEggTextMeshPro != null)
        {
            if (hasEatenEgg)
            {
                eatEggTextMeshPro.text = "Eat Egg Done"; // Set to "Eat Egg Done" if egg has been eaten
            }
            else
            {
                eatEggTextMeshPro.text = "Eat Egg"; // Set to "Eat Egg" if egg hasn't been eaten
            }
        }
    }

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

        if (Input.GetKeyDown(KeyCode.E))
        {
            EatEgg();
        }

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
                isLookingAtOrangeJuice = true;
                isLookingAtPanWithFriedEgg = false; // Ensure only one interaction is active
            }
            else if (hit.collider.gameObject.CompareTag("PanWithFriedEgg"))
            {
                panWithFriedEgg = hit.collider.gameObject;
                isLookingAtPanWithFriedEgg = true;
                isLookingAtOrangeJuice = false; // Ensure only one interaction is active
            }
            else
            {
                isLookingAtOrangeJuice = false;
                isLookingAtPanWithFriedEgg = false;
            }
        }
        else
        {
            isLookingAtOrangeJuice = false;
            isLookingAtPanWithFriedEgg = false;
        }
    }

    void DrinkOrangeJuice()
    {
        if (orangeJuice != null)
        {
            // Implement logic for drinking orange juice
            Destroy(orangeJuice);
            if (drinkSound != null)
            {
                drinkSound.Play();
            }
            isLookingAtOrangeJuice = false;
        }
    }

    void EatPanWithFriedEgg()
    {
        if (panWithFriedEgg != null)
        {
            // Implement logic for eating pan with fried egg
            Destroy(panWithFriedEgg);
            if (eatSound != null)
            {
                eatSound.Play();
            }
            hasEatenEgg = true; // Assuming this means the egg is eaten
            if (eatEggTextMeshPro != null)
            {
                eatEggTextMeshPro.text = "Eat Egg Done";
            }
            isLookingAtPanWithFriedEgg = false;
        }
    }

    void EatEgg()
    {
        // Placeholder for eating egg logic if needed
    }
}
