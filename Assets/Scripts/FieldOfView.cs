using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;

    private void OnDrawGizmos()
    {

        Vector3 upVector = new Vector3(0,0,10);
        Vector3 rightVector = new Vector3(10,0,0);

        Vector3 rightDiagonal = upVector + rightVector;
        Vector3 leftDiagonal = new Vector3(-rightDiagonal.x, rightDiagonal.y,rightDiagonal.z);

        float angle = Vector3.Angle(upVector, leftDiagonal);

        for (int i = 0; i < enemies.Length; i++)
        {
            float enemyAngle = Vector3.Angle(upVector, enemies[i].transform.position);
            print(enemyAngle);


            if (enemyAngle < angle)
            {
                //Debug.Log($"Enemy detected { enemies[i].name}");
            }

            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, enemies[i].transform.position);
        }

        Gizmos.DrawLine(transform.position, upVector);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, rightVector); 
        
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, rightDiagonal);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, leftDiagonal);
    }
}
