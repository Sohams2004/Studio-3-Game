using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] backGroundMusic, voice, sfxSounds;
    public AudioSource backGroundMusicSource, voiceSource, sfxSource;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void BackgroundMusic(string name)
    {
        Sound s = Array.Find(backGroundMusic, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Sound Not Found");

        }
        else
        {
            backGroundMusicSource.clip = s.clip;
            backGroundMusicSource.Play();
        }
    }
    public void Voice(string name)
    {
        Sound s = Array.Find(voice, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Sound Not Found");

        }
        else
        {
            voiceSource.clip = s.clip;
            voiceSource.Play();
        }
    }
    public void SFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Sound Not Found");

        }
        else
        {
            sfxSource.clip = s.clip;

        }
    }
}
