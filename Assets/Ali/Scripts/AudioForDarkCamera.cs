using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioForDarkCamera : MonoBehaviour
{
    public AudioSource audioSource; 

   
    public void PlayAudio()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    public void StopAudio()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }
}
