using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject MainMenu;
    public GameObject OptionsPanel;
    public GameObject PauseMenu;
    public GameObject GameOverPanel;
    public GameObject GUI;

    public void ShowMainMenu()
    {
        MainMenu.SetActive(true);
    }

    public void HideMainMenu()
    {
        MainMenu.SetActive(false);
    }

    public void ToggleOptionsPanel()
    {
        OptionsPanel.SetActive(!OptionsPanel.activeInHierarchy);
    }

    public void HideOptionsPanel()
    {
        OptionsPanel.SetActive(false);
    }

    public void TogglePauseMenu()
    {
        PauseMenu.SetActive(!PauseMenu.activeInHierarchy);
        OptionsPanel.SetActive(false);
    }

    public void ShowGUI()
    {
        GUI.SetActive(true);
    }
    public void HideGUI()
    {
        GUI.SetActive(false);
    }

    public void ShowGameOverPanel()
    {
        HideGUI();
        GameOverPanel.SetActive(true);
    }

} // end class UIManager
