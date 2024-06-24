using System.Collections;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float waitTime = 0.3f;
    [SerializeField] private float turnSpeed = 100;

    [SerializeField] Transform waypointHolder;

    void Start()
    {

        Vector3[] waypoints = new Vector3[waypointHolder.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = waypointHolder.GetChild(i).position;
            waypoints[i] = new Vector3(waypoints[i].x, transform.position.y, waypoints[i].z);
        }

        StartCoroutine(PathFollow(waypoints));
    }

    /* IEnumerator TurnToFace(Vector3 lookTarget)
     {
         Time.timeScale = 0.5f;
         Vector3 dirToLookTarget = (lookTarget - transform.position).normalized;
         float targetAngle = 45 - Mathf.Atan2(dirToLookTarget.z, dirToLookTarget.x) * Mathf.Rad2Deg;

         while (Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle) > 0.05f)
         {
             float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetAngle, turnSpeed * Time.deltaTime);
             transform.eulerAngles = Vector3.up * angle;
             yield return null;
         }

     }*/

    IEnumerator PathFollow(Vector3[] waypoints)
    {
        transform.position = waypoints[0];

        int targetWaypointIndex = 1;
        Vector3 targetWaypoint = waypoints[targetWaypointIndex];

        while (true)
        {
            transform.LookAt(targetWaypoint);

            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);
            if (transform.position == targetWaypoint)
            {
                targetWaypointIndex = (targetWaypointIndex + 1) % waypoints.Length;
                targetWaypoint = waypoints[targetWaypointIndex];
                yield return new WaitForSeconds(waitTime);
                //yield return StartCoroutine(TurnToFace(targetWaypoint));

                Time.timeScale = 0.5f;
            }
            yield return null;
        }
    }
}