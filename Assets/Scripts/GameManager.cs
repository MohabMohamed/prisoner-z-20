using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public playerController player;
	public bool isPaused;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
		FindObjectOfType<AudioManager> ().playGameplay ();
		player.gameObject.SetActive (false);
		Time.timeScale = 0;
	}

	public void startGame(){
		Time.timeScale = 1;
		player.gameObject.SetActive (true);
		resumeGame ();
	}

	public void pauseGame(){ //Any animator you wanna keep --> animator: Update Mode: Unscaled Time
		Time.timeScale = 0;
		isPaused = true;
	}

	public void resumeGame(){
		Time.timeScale = 1;
		isPaused = false;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape) && !isPaused && FindObjectOfType<UIManager>().mainMenuOn == false) {
			FindObjectOfType<UIManager> ().showPauseMenu ();
			pauseGame ();
		} else if (isPaused && Input.GetKeyDown (KeyCode.Escape)) {
			FindObjectOfType<UIManager> ().hidePauseMenu ();
			resumeGame ();
		}
	}
}
