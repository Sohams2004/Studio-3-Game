using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cars : MonoBehaviour
{
    [SerializeField] private float carSpeed;

    [SerializeField] public int startPoint;
    [SerializeField] public int pointIndex;

    [SerializeField] public Transform[] points;

    private void Update()
    {
        if (Vector2.Distance(transform.position, points[pointIndex].position) < 0.01f)
        {
            pointIndex += 1;

            if (pointIndex == points.Length)
            {
                pointIndex = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, points[pointIndex].position, carSpeed * Time.deltaTime);
    }
}
