using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    public Transform player;  
    public float moveSpeed = 5f;  
    public float rotationSpeed = 5f; 
    [SerializeField] private DamageScript damageScript;

    private void Update()
    {
        if (player != null)
        {
            MoveTowardsPlayer();
            FacePlayer();
        }
    }

    private void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;

        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    private void FacePlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            damageScript.DamageReceived(100);
        }
    }

    
    public void SetPlayer(Transform playerTransform)
    {
        player = playerTransform;
    }
}
