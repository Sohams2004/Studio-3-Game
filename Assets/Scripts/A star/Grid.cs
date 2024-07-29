using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] GameObject nodePrefab;

    [SerializeField] int gridArraySize;

    [SerializeField] public int gridNodeCountX;
    [SerializeField] public int gridNodeCountZ;

    [SerializeField] int nodeWidth;
    [SerializeField] int nodeHeight;

    [SerializeField] bool isWalkable;

    [SerializeField] Node[] nodes;

    private void Start()
    {
        gridArraySize = gridNodeCountX * gridNodeCountZ;

        nodes = new Node[gridArraySize];

        for (int x = 0; x < gridNodeCountZ; x++)
        {
            for (int z = 0; z < gridNodeCountX; z++)
            {
                int a = x + z * gridNodeCountX;

                Vector3Int gridPos = new Vector3Int(x, 0, z);
                Vector3 worldPos = new Vector3(x * nodeWidth, 0, z * nodeHeight);

                GameObject go = null;

                bool isWalkable = !Physics.CheckBox(worldPos, new Vector3(nodeWidth / 2.0f, 0, nodeHeight / 2.0f));

                nodes[a] = new Node(gridPos, worldPos, isWalkable, go);
            }
        }
    }

    public Node GetNode(Vector3Int GridPosition)
    {
        int i = GridPosition.x + GridPosition.z * gridNodeCountX;
        return nodes[i];
    }
}
