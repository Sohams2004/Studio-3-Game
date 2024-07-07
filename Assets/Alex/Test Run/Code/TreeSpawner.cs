using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    public GameObject treePrefab;
    public int treeCount = 500;
    public float areaSize = 50f;

    void Start()
    {
        SpawnTrees();
    }

    void SpawnTrees()
    {
        for (int i = 0; i < treeCount; i++)
        {
            float x = Random.Range(-areaSize, areaSize);
            float z = Random.Range(-areaSize, areaSize);
            Vector3 position = new Vector3(x, 50, z);

            Instantiate(treePrefab, position, Quaternion.identity);
        }
    }
}