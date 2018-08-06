using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public GameObject MainMenuObject;
    public GameObject OptionsPanel;
    public GameObject PauseMenu;

    public void ShowMainMenu()
    {
        MainMenuObject.SetActive(true);
    }

    public void HideMainMenu()
    {
        MainMenuObject.SetActive(false);
    }

   public void ToggleOptionsPanel()
    {
        Debug.Log(OptionsPanel.activeInHierarchy);
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

}
