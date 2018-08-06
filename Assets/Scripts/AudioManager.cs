using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour {

    public AudioClip MainMusicClip, GameplayClip, GunShotClip , BTNClickSFX;
    public List<AudioClip> JumpClips;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


	public void PlayMainMenuMusic()
    {
        GetComponent<AudioSource>().clip = MainMusicClip;
        GetComponent<AudioSource>().Play();
    }
    public void PlayGameplayMusic()
    {
        GetComponent<AudioSource>().clip = GameplayClip;
        GetComponent<AudioSource>().Play();
    }
    public void ToggleMusic()
    {
        if (GetComponent<AudioSource>().isPlaying)
            GetComponent<AudioSource>().Pause();
        else
            GetComponent<AudioSource>().Play();
    }


    public void PlayGunShotSFX()
    {
        AudioSource s = gameObject.AddComponent<AudioSource>();
        s.clip = GunShotClip;
        s.Play();
        Destroy(s, GunShotClip.length);
    }
    public void PlayJumpSFX()
    {
        int randomIndex = Random.Range(0 , JumpClips.Count);
        AudioSource s = gameObject.AddComponent<AudioSource>();
        s.clip = JumpClips[randomIndex];
        s.Play();
        Destroy(s, JumpClips[randomIndex].length);
    }
    public void PlayBTNSFX()
    {
        AudioSource s = gameObject.AddComponent<AudioSource>();
        s.clip = BTNClickSFX;
        s.Play();
        Destroy(s, BTNClickSFX.length);
    }
}// end class AudioManager
