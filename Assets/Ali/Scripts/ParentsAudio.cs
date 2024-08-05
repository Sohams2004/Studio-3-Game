using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentsAudio : MonoBehaviour
{
    public AudioSource voiceLine1; 
    public AudioSource voiceLine2; 
    public float timeToPlayVoiceLine1 = 5f; 
    public float timeToPlayVoiceLine2 = 10f; 
    private bool voiceLine1Played = false;
    private bool voiceLine2Played = false;

    private void OnEnable()
    {
        voiceLine1Played = false;
        voiceLine2Played = false;
        timer = 0f;
    }

    private float timer = 0f;

    void Update()
    {  
        timer += Time.deltaTime;

        if (timer >= timeToPlayVoiceLine1 && !voiceLine1Played)
        {
            voiceLine1.Play();
            voiceLine1Played = true;
        }

        if (timer >= timeToPlayVoiceLine2 && !voiceLine2Played)
        {
            voiceLine2.Play();
            voiceLine2Played = true;
        }
    }
}
