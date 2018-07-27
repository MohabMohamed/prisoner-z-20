using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public GameObject MainMenuObject;

    public void ShowMainMenu()
    {
        MainMenuObject.SetActive(true);
    }

    public void HideMainMenu()
    {
        MainMenuObject.SetActive(false);
    }

   


}
