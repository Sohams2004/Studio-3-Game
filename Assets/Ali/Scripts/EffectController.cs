using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    public ParticleSystem particleEffect; // Reference to the particle system

    private bool hasCollided = false; // Flag to track if collision has occurred
    private float startTime; // Time when particle effect started

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasCollided)
        {
            // Set flag to true to prevent multiple triggers
            hasCollided = true;

            // Start the particle effect
            particleEffect.Play();
            startTime = Time.time;

            // Schedule the stopping of particle effect
            Invoke("StopParticleEffect", 10f); // Stop after 10 seconds
        }
    }

    private void StopParticleEffect()
    {
        particleEffect.Stop();
    }
}
