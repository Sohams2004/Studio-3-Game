using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooking : MonoBehaviour
{
    public GameObject milkshakeCupPrefab; // Assign the milkshake cup prefab in the inspector
    public GameObject sushiPrefab; // Assign the sushi prefab in the inspector
    public Transform spawnPoint; // Assign the desired spawn point in the inspector

    private bool isFirstObjectInBox = false;
    private bool isSecondObjectInBox = false;
    private GameObject firstObject;
    private GameObject secondObject;

    private Dictionary<(string, string), GameObject> foodCombinations;

    private void Start()
    {
        foodCombinations = new Dictionary<(string, string), GameObject>
        {
            { ("Banana", "Milk"), milkshakeCupPrefab },
            { ("Fish", "Fish"), sushiPrefab }
        };
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isFirstObjectInBox)
        {
            isFirstObjectInBox = true;
            firstObject = other.gameObject;
        }
        else if (!isSecondObjectInBox)
        {
            isSecondObjectInBox = true;
            secondObject = other.gameObject;
        }

        CheckAndMakeFood();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == firstObject)
        {
            isFirstObjectInBox = false;
            firstObject = null;
        }
        if (other.gameObject == secondObject)
        {
            isSecondObjectInBox = false;
            secondObject = null;
        }
    }

    private void CheckAndMakeFood()
    {
        if (isFirstObjectInBox && isSecondObjectInBox)
        {
            string firstTag = firstObject.tag;
            string secondTag = secondObject.tag;

            if (foodCombinations.TryGetValue((firstTag, secondTag), out GameObject resultPrefab) ||
                foodCombinations.TryGetValue((secondTag, firstTag), out resultPrefab))
            {
                StartCoroutine(MakeFoodWithDelay(resultPrefab, 2f));
            }
        }
    }

    private IEnumerator MakeFoodWithDelay(GameObject resultPrefab, float delay)
    {
        yield return new WaitForSeconds(delay);

        Instantiate(resultPrefab, spawnPoint.position, spawnPoint.rotation);

        Destroy(firstObject);
        Destroy(secondObject);

        isFirstObjectInBox = false;
        isSecondObjectInBox = false;
    }
}
