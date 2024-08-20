using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item2 : MonoBehaviour
{
    [SerializeField] TMP_Text pickUpText;
    public Camera playerCamera; // Assign your player camera
    public Image orangeImage;   // Assign UI Image component for orange
    public Image toastImage;    // Assign UI Image component for toast
    public Image eggImage;      // Assign UI Image component for egg
    public Sprite orangeSprite; // Assign your orange sprite
    public Sprite toastSprite;  // Assign your toast sprite
    public Sprite eggSprite;    // Assign your egg sprite
    public float placementDistance = 2f; // Distance in front of the player to place the item

    private List<GameObject> pickedItems = new List<GameObject>();
    private Dictionary<string, GameObject> itemDictionary = new Dictionary<string, GameObject>();

    void Start()
    {
        // Hide all images initially
        orangeImage.enabled = false;
        toastImage.enabled = false;
        eggImage.enabled = false;
    }

    void Update()
    {
        // Check for object pickup
        if (Input.GetKeyDown(KeyCode.G))
        {
            RaycastHit hit;
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.collider.gameObject;
                string tag = hitObject.tag;

                if (tag == "Orange" || tag == "Toast" || tag == "Egg")
                { 
                    pickUpText.text = "Object can be drop with 1, 2, 3";

                    if (!pickedItems.Contains(hitObject))
                    {
                        HideItem(hitObject);
                        pickedItems.Add(hitObject);
                        itemDictionary[tag] = hitObject;
                        UpdateUI();
                    }
                }
            }
        }

        // Check for item placement
        if (Input.GetKeyDown(KeyCode.Alpha1) && itemDictionary.ContainsKey("Orange"))
        {
            PlaceItem(itemDictionary["Orange"], "Orange");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && itemDictionary.ContainsKey("Toast"))
        {
            PlaceItem(itemDictionary["Toast"], "Toast");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && itemDictionary.ContainsKey("Egg"))
        {
            PlaceItem(itemDictionary["Egg"], "Egg");
        }
    }

    void HideItem(GameObject item)
    {
        item.SetActive(false);
    }

    void UpdateUI()
    {
        // Set all images to be invisible initially
        orangeImage.enabled = false;
        toastImage.enabled = false;
        eggImage.enabled = false;

        // Display UI images for the items currently held
        foreach (var item in itemDictionary)
        {
            switch (item.Key)
            {
                case "Orange":
                    orangeImage.sprite = orangeSprite;
                    orangeImage.enabled = true;
                    break;
                case "Toast":
                    toastImage.sprite = toastSprite;
                    toastImage.enabled = true;
                    break;
                case "Egg":
                    eggImage.sprite = eggSprite;
                    eggImage.enabled = true;
                    break;
            }
        }
    }

    void PlaceItem(GameObject item, string tag)
    {
        item.SetActive(true);

        // Calculate the position in front of the player
        Vector3 placementPosition = playerCamera.transform.position + playerCamera.transform.forward * placementDistance;
        item.transform.position = placementPosition;

        // Optional: Adjust the item's rotation to face the player or a specific direction
        item.transform.rotation = Quaternion.identity; // Reset rotation, adjust if needed

        pickedItems.Remove(item);
        itemDictionary.Remove(tag);
        UpdateUI(); // Update the UI to reflect the remaining items
    }
}
