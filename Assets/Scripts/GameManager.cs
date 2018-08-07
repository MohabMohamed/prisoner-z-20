using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public PlayerController player;

    public bool isGameON { get; set; }


    // Use this for initialization
    void Start () {
        isGameON = false;

        DontDestroyOnLoad(gameObject);
        ServiceLocator.GetService<AudioManager>().PlayMainMenuMusic();

        player.gameObject.SetActive(false);

	}
	

    public void StartGame()
    {
        isGameON = true;
        player.gameObject.SetActive(true);
    }

    public void PauseGame()
    {
        isGameON = false;
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        isGameON = true;
        Time.timeScale = 1;
    }
    
    public bool IsPaused()
    {
        if (Time.timeScale == 0)
            return true;
        else return false;
    }


	// Update is called once per frame
	void Update () {
		
	}



}
