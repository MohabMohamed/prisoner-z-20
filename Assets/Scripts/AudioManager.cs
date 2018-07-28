using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour {

	//Clips
	public AudioClip MainMenuClip, GameplayClip, GunClip, JumpClip;

	void Awake(){
		DontDestroyOnLoad (gameObject);
	}

	// Update is called once per frame
	public void playMainMenu () { //Main music
		GetComponent<AudioSource> ().clip = MainMenuClip;
		GetComponent<AudioSource> ().Play ();
	}

	public void playGameplay(){ //gameplay music
		GetComponent<AudioSource> ().clip = GameplayClip;
		GetComponent<AudioSource> ().Play ();
	}

	public void toggleMusic(){ 
		if (GetComponent<AudioSource> ().isPlaying)
			GetComponent<AudioSource> ().Pause ();
		else
			GetComponent<AudioSource> ().Play ();
	}

	public void playGunSFX(){
		AudioSource s = gameObject.AddComponent<AudioSource> ();
		s.clip = GunClip;
		s.Play ();
		Destroy (s, GunClip.length);
	}

	public void playJumpSFX(){
		AudioSource s = gameObject.AddComponent<AudioSource> ();
		s.clip = JumpClip;
		s.Play ();
		Destroy (s, JumpClip.length);
	}
}
