using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    public ParticleSystem particleEffect; 

    private bool hasCollided = false; 
    private float startTime; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasCollided)
        {
            hasCollided = true;

            particleEffect.Play();
            startTime = Time.time;

            
            Invoke("StopParticleEffect", 10f); 
        }
    }

    private void StopParticleEffect()
    {
        particleEffect.Stop();
    }
}
