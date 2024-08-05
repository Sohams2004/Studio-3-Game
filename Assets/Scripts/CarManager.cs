using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    [SerializeField] List<GameObject> carsPrefab;
    [SerializeField] float spawnTime, spawnInterval;

    [SerializeField] Transform[] points;

    [SerializeField] Vector3Int start, end;

    [SerializeField] int numberOfCars;
    [SerializeField] int maxnumberOfCars;
    [SerializeField] int currentNoOfCars;

    [SerializeField] AStar aStar;
    [SerializeField] Grid grid;

    private void Start()
    {
        /*if (points == null || points.Length == 0)
        {
            Debug.LogError("Points array is empty!");
            return;
        }
        StartCoroutine(SpawnCarsAtIntervals());*/

        aStar = FindObjectOfType<AStar>();
        grid = FindObjectOfType<Grid>();   
    }

    /*void SpawnCars()
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
    }*/

    void SpawnCars()
    {
        List<Node> path = aStar.GetPath(start, end);
        if (path != null && carsPrefab.Count > 0)
        {
            Vector3 startPosition = grid.WorldPosition(start);
            Debug.Log(startPosition + " " + start);

            GameObject randomCarPrefab = carsPrefab[Random.Range(0, carsPrefab.Count)];

            GameObject carObject = Instantiate(randomCarPrefab, startPosition, Quaternion.Euler(0, 180, 0));
            Cars car = carObject.GetComponent<Cars>();
            if (car != null)
            {
                car.SetPath(path);
            }
            else
            {
                Debug.LogError("Car component not found on the spawned car prefab!");
            }
        }
    }

    private void Update()
    {
        spawnTime += Time.deltaTime;
        if (spawnTime >= spawnInterval && transform.childCount < numberOfCars)
        {
            SpawnCars();
            spawnTime = 0f;
        }
    }
}
