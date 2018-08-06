using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public PlayerController player;


	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        ServiceLocator.GetService<AudioManager>().PlayMainMenuMusic();

        player.gameObject.SetActive(false);

	}
	

    public void StartGame()
    {
        player.gameObject.SetActive(true);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }


	// Update is called once per frame
	void Update () {
		
	}



}
