using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterAI : MonoBehaviour
{
    public Transform player;  // Reference to the player
    public float moveSpeed = 5f;  // Speed at which the monster moves

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
        // Calculate the rotation needed to face the player
        Quaternion targetRotation = Quaternion.LookRotation(player.position - transform.position);

        // Smoothly rotate the monster to face the player
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * moveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the monster collided with the player
        if (other.CompareTag("Player"))
        {
            // Reload the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // Method to set the player reference
    public void SetPlayer(Transform playerTransform)
    {
        player = playerTransform;
    }
}
