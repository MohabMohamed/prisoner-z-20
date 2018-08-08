using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

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

    internal void OnPlayerDied()
    {
        isGameON = false;

        foreach (Enemy e in FindObjectsOfType<Enemy>())
        {
            e.OnPlayerDied();
        }

        ServiceLocator.GetService<UIManager>().ShowGameOverPanel();
        ServiceLocator.GetService<UIManager>().GetGameOverPanel().transform.Find("Total Score").GetComponent<TextMeshProUGUI>().text = "Total Score: " + ServiceLocator.GetService<ScoreManager>().getScore();
        ServiceLocator.GetService<AudioManager>().PlayGameOverMusic();

    }





    public void Application_Exit()
    {
        Application.Quit();
    }
    public void Application_Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
