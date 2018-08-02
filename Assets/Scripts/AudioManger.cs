using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManger : MonoBehaviour {
 
    public AudioMixer MasterAudioMixer;
    [Space]
    [Header("Sounds")]
    public Sound[] sounds;
   
  

    void Awake()
    {
     

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.mixerGroup;
        }
        Play("MainMenuTheme");
    }

    public void Play(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.volume = s.volume;
        s.source.pitch = s.pitch;

        s.source.Play();
        
    }

    public void Stop(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        if(s.source.isPlaying)
        s.source.Stop();

    }

    public void SetMasterVolume(float SoundLevel)
    {
        MasterAudioMixer.SetFloat("MainVolume", SoundLevel);

    }

    public void SetMusicVolume(float SoundLevel)
    {
        MasterAudioMixer.SetFloat("MusicVolume", SoundLevel);

    }

    public void SetSFXVolume(float SoundLevel)
    {
        MasterAudioMixer.SetFloat("SFXVolume", SoundLevel);

    }

}
