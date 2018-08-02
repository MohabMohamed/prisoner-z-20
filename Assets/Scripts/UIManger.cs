using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class UIManger : MonoBehaviour {


    public Dropdown resolutionDropdown;
    Resolution[] resolutions;

    public void Start()
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
    public void Play()
    {
        FindObjectOfType<AudioManger>().Stop("MainMenuTheme");
        Debug.Log("Play");
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        FindObjectOfType<AudioManger>().Play("GamePlayTheme");

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

    public void SetResolution(int resolutionIdx)
    {
        Screen.SetResolution(resolutions[resolutionIdx].width,
            resolutions[resolutionIdx].height, Screen.fullScreen);
    }

}
