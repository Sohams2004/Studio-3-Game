using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooking : MonoBehaviour
{
    public GameObject banana; // Assign the banana GameObject in the inspector
    public GameObject apple;  // Assign the apple GameObject in the inspector
    public GameObject milkshakeCupPrefab; // Assign the milkshake cup prefab in the inspector
    public Transform spawnPoint; // Assign the desired spawn point in the inspector

    private bool isBananaInBox = false;
    private bool isAppleInBox = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == banana)
        {
            isBananaInBox = true;
        }
        if (other.gameObject == apple)
        {
            isAppleInBox = true;
        }

        CheckAndMakeMilkshake();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == banana)
        {
            isBananaInBox = false;
        }
        if (other.gameObject == apple)
        {
            isAppleInBox = false;
        }
    }

    private void CheckAndMakeMilkshake()
    {
        if (isBananaInBox && isAppleInBox)
        {
            // Start the coroutine to handle the delay
            StartCoroutine(MakeMilkshakeWithDelay(2f));
        }
    }

    private IEnumerator MakeMilkshakeWithDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Instantiate the milkshake cup at the specified spawn point
        Instantiate(milkshakeCupPrefab, spawnPoint.position, spawnPoint.rotation);

        // Destroy the banana and apple objects
        Destroy(banana);
        Destroy(apple);

        // Reset the flags
        isBananaInBox = false;
        isAppleInBox = false;
    }
}
