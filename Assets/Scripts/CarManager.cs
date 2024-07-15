using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    [SerializeField] List<GameObject> carsPrefab;
    [SerializeField] float startTime, endTime;

    [SerializeField] Transform[] points;

    [SerializeField] int numberOfCars;
    [SerializeField] int maxnumberOfCars;
    [SerializeField] int currentNoOfCars;

    void SpawnCars()
    {
        for (int i = 0; i < numberOfCars; i++)
        {
            if (currentNoOfCars >= maxnumberOfCars)
            {
                Debug.Log("Maximum number of cars reached.");
                return;
            }
            Debug.Log("Instantiating car. Current number of cars: " + currentNoOfCars);

            int randomIndex = Random.Range(0, points.Length);
            int randomCarIndex = Random.Range(0, carsPrefab.Count);
            GameObject cars = Instantiate(carsPrefab[randomCarIndex], points[randomIndex].position, Quaternion.identity);

            Cars car = cars.GetComponent<Cars>();

            currentNoOfCars++;
            Debug.Log("Car instantiated. New number of cars: " + currentNoOfCars);
        }
    }

    IEnumerator SpawnCarsAtIntervals()
    {
        int carsToSpawn = maxnumberOfCars - numberOfCars;

        for (int i = 0; i < carsToSpawn; i++)
        {
            float interval = Random.Range(startTime, endTime);
            Debug.Log("Waiting for " + interval + " seconds to instantiate the next car.");
            yield return new WaitForSeconds(interval);

            SpawnCars();
        }
        Debug.Log("Finished instantiating cars.");
    }

    private void Start()
    {
        if (points == null || points.Length == 0)
        {
            Debug.LogError("Points array is empty!");
            return;
        }
        StartCoroutine(SpawnCarsAtIntervals());
    }
}
