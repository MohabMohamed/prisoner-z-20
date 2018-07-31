using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManger : MonoBehaviour {
 

    [Range(0f, 1f)]
    public float soundLevel;

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

        s.source.volume = s.volume * soundLevel;
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

    public void OnSoundLevelChanged(float newSoundLevel)
    {
        soundLevel = newSoundLevel;
        foreach (Sound s in sounds)
        {
            if (s.source.isPlaying)
            {
                s.source.volume = s.volume * soundLevel;
                
            }

        }

    }


}
