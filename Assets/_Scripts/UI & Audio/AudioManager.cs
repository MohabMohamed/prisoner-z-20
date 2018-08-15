using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour {

    public AudioClip MainMusicClip, GameplayClip, GameOverClip, GunShotClip , BTNClickSFX, PlayerHitClip;
    public List<AudioClip> JumpClips;
    public List<AudioClip> SwordClips;
    public List<AudioClip> BossEntranceClips;
    public List<AudioClip> BossDeathClips;

    void Awake()
    {
        //if(ServiceLocator.GetService<AudioManager>() == null)
        //     DontDestroyOnLoad(gameObject);
        //else
        //{
        //    Destroy(gameObject);
        //}
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
        s.volume = .5f;
        s.Play();
        Destroy(s, GunShotClip.length);
    }
    public void PlayJumpSFX() //random
    {
        int randomIndex = Random.Range(0 , JumpClips.Count);
        AudioSource s = gameObject.AddComponent<AudioSource>();
        s.clip = JumpClips[randomIndex];
        s.volume = .8f;
        s.Play();
        Destroy(s, JumpClips[randomIndex].length);
    }
    public void PlayBTNSFX()
    {
        AudioSource s = gameObject.AddComponent<AudioSource>();
        s.clip = BTNClickSFX;
        s.volume = .9f;
        s.Play();
        Destroy(s, BTNClickSFX.length);
    }
    public void PlaySwordWooshSFX()
    {
        AudioSource s = gameObject.AddComponent<AudioSource>();
        s.clip = SwordClips[0];
        s.volume = .8f;
        s.Play();
        Destroy(s, SwordClips[0].length);
    }
    public void PlaySwordHitSFX()
    {
        AudioSource s = gameObject.AddComponent<AudioSource>();
        s.clip = SwordClips[1];
        s.volume = .7f;
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
    public void PlayBossEntranceSFX() //random
    {
        int randomIndex = Random.Range(0, BossEntranceClips.Count);
        AudioSource s = gameObject.AddComponent<AudioSource>();
        s.clip = BossEntranceClips[randomIndex];
        s.volume = 1;
        s.Play();
        Destroy(s, BossEntranceClips[randomIndex].length);
    }
    public void PlayBossDeathSFX() //random
    {
        int randomIndex = Random.Range(0, BossDeathClips.Count);
        AudioSource s = gameObject.AddComponent<AudioSource>();
        s.clip = BossDeathClips[randomIndex];
        s.volume = 1;
        s.Play();
        Destroy(s, BossDeathClips[randomIndex].length);
    }
}// end class AudioManager
