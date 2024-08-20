using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item2 : MonoBehaviour
{
    [SerializeField] TMP_Text pickUpText;
    public Camera playerCamera; // Assign your player camera
    public GameObject uiPanel;  // Assign the entire UI panel
    public Image orangeImage;   // Assign UI Image component for orange
    public Image toastImage;    // Assign UI Image component for toast
    public Image eggImage;      // Assign UI Image component for egg
    public TMP_Text orangeCountText; // Assign TMP_Text component for orange count
    public TMP_Text toastCountText;  // Assign TMP_Text component for toast count
    public TMP_Text eggCountText;    // Assign TMP_Text component for egg count
    public Sprite orangeSprite; // Assign your orange sprite
    public Sprite toastSprite;  // Assign your toast sprite
    public Sprite eggSprite;    // Assign your egg sprite
    public float placementDistance = 2f; // Distance in front of the player to place the item

    private List<GameObject> pickedItems = new List<GameObject>();
    private Dictionary<string, List<GameObject>> itemDictionary = new Dictionary<string, List<GameObject>>();

    void Start()
    {
        // Disable the entire UI panel initially
        uiPanel.SetActive(false);
    }

    void Update()
    {
        // Check for object pickup
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.collider.gameObject;
                string tag = hitObject.tag;

                if (tag == "Orange" || tag == "Toast" || tag == "Egg")
                {
                    pickUpText.text = "Drop = 1,2,3";

                    if (!pickedItems.Contains(hitObject))
                    {
                        HideItem(hitObject);
                        pickedItems.Add(hitObject);

                        if (!itemDictionary.ContainsKey(tag))
                        {
                            itemDictionary[tag] = new List<GameObject>();
                        }
                        itemDictionary[tag].Add(hitObject);

                        UpdateUI();
                    }
                }
            }
        }

        // Check for item placement
        if (Input.GetKeyDown(KeyCode.Alpha1) && itemDictionary.ContainsKey("Orange") && itemDictionary["Orange"].Count > 0)
        {
            PlaceItem(itemDictionary["Orange"][0], "Orange");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && itemDictionary.ContainsKey("Toast") && itemDictionary["Toast"].Count > 0)
        {
            PlaceItem(itemDictionary["Toast"][0], "Toast");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && itemDictionary.ContainsKey("Egg") && itemDictionary["Egg"].Count > 0)
        {
            PlaceItem(itemDictionary["Egg"][0], "Egg");
        }
    }

    void HideItem(GameObject item)
    {
        item.SetActive(false);
    }

    void UpdateUI()
    {
        // Enable the UI panel
        uiPanel.SetActive(true);

        // Hide all UI elements initially
        orangeImage.enabled = false;
        toastImage.enabled = false;
        eggImage.enabled = false;
        orangeCountText.enabled = false;
        toastCountText.enabled = false;
        eggCountText.enabled = false;

        // Display UI images and counts for the items currently held
        if (itemDictionary.ContainsKey("Orange") && itemDictionary["Orange"].Count > 0)
        {
            orangeImage.sprite = orangeSprite;
            orangeImage.enabled = true;
            orangeCountText.text = $"= {itemDictionary["Orange"].Count}"; // Add equals sign and format text
            orangeCountText.enabled = true;
        }
        if (itemDictionary.ContainsKey("Toast") && itemDictionary["Toast"].Count > 0)
        {
            toastImage.sprite = toastSprite;
            toastImage.enabled = true;
            toastCountText.text = $"= {itemDictionary["Toast"].Count}"; // Add equals sign and format text
            toastCountText.enabled = true;
        }
        if (itemDictionary.ContainsKey("Egg") && itemDictionary["Egg"].Count > 0)
        {
            eggImage.sprite = eggSprite;
            eggImage.enabled = true;
            eggCountText.text = $"= {itemDictionary["Egg"].Count}"; // Add equals sign and format text
            eggCountText.enabled = true;
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
        itemDictionary[tag].Remove(item);

        // Remove the item type from the dictionary if no instances are left
        if (itemDictionary[tag].Count == 0)
        {
            itemDictionary.Remove(tag);
        }

        // Update the UI to reflect the remaining items
        UpdateUI();
    }
}
