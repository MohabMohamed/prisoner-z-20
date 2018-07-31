using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManger : MonoBehaviour {
    
 
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



}
