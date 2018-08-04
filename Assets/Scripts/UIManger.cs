using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System;

public class UIManger : MonoBehaviour {

    static public bool inGame, isPaused;
    GameObject PuaseMenuUI;
    Button quitButton,resumeButton,mainMenuButton;

    public Dropdown resolutionDropdown;
    Resolution[] resolutions;

    public void Start()
    {
        GetAvailResolutions();
        inGame = isPaused = false;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && inGame)
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    private void Pause()
    {
        PuaseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    private void Resume()
    {
        PuaseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
    }

    public void Play()
    {
        inGame = true;
        FindObjectOfType<AudioManger>().Stop("MainMenuTheme");
        Debug.Log("Play");
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        FindObjectOfType<AudioManger>().Play("GamePlayTheme");
        Invoke("InGameUiAwake", 3.0f);


    }


    public void Quit()
    {
        Debug.Log("QUIT");
        Application.Quit();

    }

    public void SetQuality(int qualityIdx)
    {
        QualitySettings.SetQualityLevel(qualityIdx);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    void GetAvailResolutions()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int curResIdx = 0;
        string option;
        for (int i = 0; i < resolutions.Length; i++)
        {
            option = resolutions[i].width + " X " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                curResIdx = i;
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = curResIdx;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIdx)
    {
        Screen.SetResolution(resolutions[resolutionIdx].width,
            resolutions[resolutionIdx].height, Screen.fullScreen);
    }
    void InGameUiAwake()
    {
        GetPauseMenu();
        resumeButton.onClick.AddListener(Resume);
        mainMenuButton.onClick.AddListener(BackToMainMenu);
        quitButton.onClick.AddListener(Quit);
    }

    void GetPauseMenu()
    {
       Debug.Log(PuaseMenuUI = GameObject.Find("Canvas/PauseMenu"));
       Debug.Log(resumeButton = GameObject.Find("Canvas/PauseMenu/ResumeButton").GetComponent<Button>());
       Debug.Log(mainMenuButton = GameObject.Find("Canvas/PauseMenu/MainMenu").GetComponent<Button>());
       Debug.Log(quitButton = GameObject.Find("Canvas/PauseMenu/QuitButton").GetComponent<Button>());
    }

    void BackToMainMenu()
    {
        Time.timeScale = 1.0f;
        inGame = false;
        FindObjectOfType<AudioManger>().Stop("GamePlayTheme");
        Debug.Log("BackToMainMenu");
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        FindObjectOfType<AudioManger>().Play("MainMenuTheme");
    }
 
}
