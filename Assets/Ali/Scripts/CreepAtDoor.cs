using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepAtDoor : MonoBehaviour
{
    public AudioSource audioSource; 
    public Collider doorCreepCollider; 
    public float audioDelay = 60f; 
    public string playerTag = "Player"; 

    private bool isAudioPlaying = false;

    private void Start()
    {
        StartCoroutine(PlayAudioAfterDelay(audioDelay));
    }

    private IEnumerator PlayAudioAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        audioSource.Play();
        isAudioPlaying = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            if (isAudioPlaying)
            {
                audioSource.Stop();
                isAudioPlaying = false; 
            }
        }
    }
}
