using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySystem : MonoBehaviour
{
     public List<GameObject> inventoryItems = new List<GameObject>(); // List to store inventory items
    public List<Sprite> itemIcons; // List of item icons (assign in Inspector)
    public List<Image> inventorySlots; // List of inventory slot images (assign in Inspector)
    public GameObject inventoryPanel; // The inventory UI panel
    public Transform spawnPoint; // The point in front of the player where items will be spawned
    public TMP_Text notificationText; // Notification text (e.g., "Object in inventory")

    private void Update()
    {
        // Toggle inventory panel visibility with 'I'
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }

        // Handle item pickup with 'G'
        if (Input.GetKeyDown(KeyCode.G))
        {
            PickUpItem();
        }

        // Handle item selection with '1', '2', '3'
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SpawnItem(0); // Spawn the first item in the inventory
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SpawnItem(1); // Spawn the second item in the inventory
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SpawnItem(2); // Spawn the third item in the inventory
        }
    }

    private void PickUpItem()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            GameObject pickedUpObject = hit.collider.gameObject;

            // Check for specific tags
            if (pickedUpObject.CompareTag("Toast") ||
                pickedUpObject.CompareTag("Orange") ||
                pickedUpObject.CompareTag("Egg"))
            {
                // Add the object to the inventory
                if (!inventoryItems.Contains(pickedUpObject))
                {
                    inventoryItems.Add(pickedUpObject);

                    // Update inventory UI
                    UpdateInventoryUI();

                    // Disable the picked-up object in the scene
                    pickedUpObject.SetActive(false);

                    // Show notification
                    notificationText.text = pickedUpObject.name + " added to inventory!";
                }
            }
        }
    }

    private void UpdateInventoryUI()
    {
        // Clear all inventory slots
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            inventorySlots[i].sprite = null;
            inventorySlots[i].gameObject.SetActive(false);
        }

        // Update only the slots that have items in the inventory
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (i < inventorySlots.Count)
            {
                inventorySlots[i].sprite = itemIcons[i]; // Assign the correct icon to the slot
                inventorySlots[i].gameObject.SetActive(true); // Make the slot visible
            }
        }
    }

    private void ToggleInventory()
    {
        // Toggle the active state of the inventory panel
        bool isActive = !inventoryPanel.activeSelf;
        inventoryPanel.SetActive(isActive);

        // Enable or disable the cursor based on the inventory panel's active state
        if (isActive)
        {
            Cursor.lockState = CursorLockMode.None; // Unlock the cursor
            Cursor.visible = true; // Make the cursor visible
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked; // Lock the cursor back to the center
            Cursor.visible = false; // Hide the cursor
        }
    }

    private void SpawnItem(int index)
    {
        if (index < inventoryItems.Count && inventoryItems[index] != null)
        {
            // Remove existing item if any at the spawn point
            foreach (Transform child in spawnPoint)
            {
                Destroy(child.gameObject);
            }

            // Get the item from the inventory
            GameObject itemToSpawn = inventoryItems[index];

            // Instantiate the item at the spawn point
            GameObject spawnedItem = Instantiate(itemToSpawn, spawnPoint.position, spawnPoint.rotation);

            // Reactivate the spawned item
            spawnedItem.SetActive(true);

            // Make the spawned item a child of the spawn point to keep it in position
            spawnedItem.transform.SetParent(spawnPoint);
        }
    }
}
