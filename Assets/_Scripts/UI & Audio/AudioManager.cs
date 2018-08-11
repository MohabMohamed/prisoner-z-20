using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour {

    public AudioClip MainMusicClip, GameplayClip, GameOverClip, GunShotClip , BTNClickSFX, PlayerHitClip;
    public List<AudioClip> JumpClips;
    public List<AudioClip> SwordClips;

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
        GetComponent<AudioSource>().volume = 0.5f;
    }

    public void PlayGameOverMusic()
    {
        GetComponent<AudioSource>().clip = GameOverClip;
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().volume = 0.75f;
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
    public void PlayJumpSFX() //random
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
    public void PlaySwordWooshSFX()
    {
        AudioSource s = gameObject.AddComponent<AudioSource>();
        s.clip = SwordClips[0];
        s.Play();
        Destroy(s, SwordClips[0].length);
    }
    public void PlaySwordHitSFX()
    {
        AudioSource s = gameObject.AddComponent<AudioSource>();
        s.clip = SwordClips[1];
        s.Play();
        Destroy(s, SwordClips[1].length);
    }
    public void PlayPlayerHitSFX()
    {
        AudioSource s = gameObject.AddComponent<AudioSource>();
        s.clip = PlayerHitClip;
        s.Play();
        Destroy(s, PlayerHitClip.length);
    }


}// end class AudioManager
