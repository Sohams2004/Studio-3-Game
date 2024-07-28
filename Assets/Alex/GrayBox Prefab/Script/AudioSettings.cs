using UnityEngine;
using UnityEngine.Audio;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);

    }
    public void SetSoundEffectsVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
    }

    public void SetVoiceVolume(float volume)
    {
        audioMixer.SetFloat("VoiceVolume", Mathf.Log10(volume) * 20);

    }

    public void SetBackgroundMusicVolume(float volume)
    {
        audioMixer.SetFloat("Background", Mathf.Log10(volume) * 20);
    }
}
