using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    public Transform player;  // Reference to the player
    public float moveSpeed = 5f;  // Speed at which the monster moves
    public float rotationSpeed = 5f; // Speed at which the monster rotates
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
        // Calculate the direction to the player
        Vector3 direction = (player.position - transform.position).normalized;

        // Move the monster towards the player
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    private void FacePlayer()
    {
        // Calculate the direction to the player
        Vector3 direction = (player.position - transform.position).normalized;

        // Apply a 90-degree rotation around the Y-axis
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // Smoothly rotate the monster to face the player with the added rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the monster collided with the player
        if (other.CompareTag("Player"))
        {
            damageScript.DamageReceived(100);
        }
    }

    // Method to set the player reference
    public void SetPlayer(Transform playerTransform)
    {
        player = playerTransform;
    }
}
