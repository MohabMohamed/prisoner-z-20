using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public GameObject MainMenu;
    public GameObject OptionsPanel;
    public GameObject PauseMenu;
    public GameObject GameOverPanel;
    public GameObject GUI;
    public Image HealthBar;

    public GameObject TouchInputCanvas;

    void Start()
    {
        HideTouchInput();
    }


    void ShowTouchInput()
    {
        if (ServiceLocator.GetService<GameManager>().isTouchInput)
        {
            TouchInputCanvas.SetActive(true);
        }
    }
    void HideTouchInput()
    {
        TouchInputCanvas.SetActive(false);
    }

    void Update()
    {

    }

    public void UpdateHealtBar()
    {
        HealthBar.fillAmount = ServiceLocator.GetService<PlayerController>().gameObject.GetComponent<HealthSystem>().GetHealth() / ServiceLocator.GetService<PlayerController>().gameObject.GetComponent<HealthSystem>().GetMaxHealth();
    }

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
        ShowTouchInput();
    }
    public void HideGUI()
    {
        GUI.SetActive(false);
        HideTouchInput();
    }

    public void ShowGameOverPanel()
    {
        HideGUI();
        GameOverPanel.SetActive(true);
    }
    public GameObject GetGameOverPanel()
    {
        return GameOverPanel;
    }
    public void ShowScore()
    {
        ServiceLocator.GetService<ScoreManager>().GetComponent<ScoreManager>().getScore();
    }
    
} // end class UIManager
