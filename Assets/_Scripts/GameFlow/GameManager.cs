using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour {

    public PlayerController player;

    public bool isGameON { get; set; }
    public bool isBossON { get; set; }
    public bool isWaveOn { get; set; }

    public TextMeshProUGUI MsgTXT;

    [Header("Waves Rules")]
    public float initialWaveTimeInSecs;
    public float WaveTimeIncrement;
    public float MaxWaveTime;
    [Space]
    public int initialMaxEnemies;
    public int maxEnemiesIncrement;

    [Space]
    [Header("Boss Rules")]
    public GameObject BossEnemy;
    public EnemySpawner BossEnemySpawner;
    public float BossHealthIncrement;
    public float BossDamageIncrement;
    public int BossAfterKamWave;

    // --------------------------------------

    int _currentEnemiesCount;
    [HideInInspector]
    public int CurrentEnemiesCount
    {
        get { return _currentEnemiesCount; }
        set {
            Debug.Log("Current : " + _currentEnemiesCount + " | value : " + value);
            if(value > _currentEnemiesCount)
            {
                currentTotalSpawnedEnemies++;
            }
            if (_currentEnemiesCount > 0 && value == 0 && currentTotalSpawnedEnemies >= CurrentMaxEnemiesCount )
            {
                endWave();
            }
            _currentEnemiesCount = value;
        }
    }
    [HideInInspector]
    public int CurrentMaxEnemiesCount { get; set; }

    int currentWaveNum;
    [HideInInspector]
    public int currentTotalSpawnedEnemies { get; set; }
    float currentWaveTime;


    // Use this for initialization
    void Start () {
        isGameON = false;
        isBossON = false;
        isWaveOn = false;

        //DontDestroyOnLoad(gameObject);
        ServiceLocator.GetService<AudioManager>().PlayMainMenuMusic();

        player.gameObject.SetActive(false);

        CurrentEnemiesCount = 0;
	}

    public void StartGame()
    {
        player.gameObject.SetActive(true);
        isGameON = true;

        prepareWave(1);
    }

    void prepareWave(int waveNum)
    {
        currentWaveNum = waveNum;
        ShowMsg("Wave " + currentWaveNum);

        currentWaveTime = initialWaveTimeInSecs + (WaveTimeIncrement * (currentWaveNum - 1)) ;
        currentWaveTime = currentWaveTime > MaxWaveTime ? MaxWaveTime : currentWaveTime;

        CurrentEnemiesCount = currentTotalSpawnedEnemies =  0;
        CurrentMaxEnemiesCount = initialMaxEnemies + (maxEnemiesIncrement * (currentWaveNum -1));

        LeanTween.delayedCall(1f, () => 
        {
            isWaveOn = true;

            Invoke("endWave" , currentWaveTime);
        });


    }

    void endWave()
    {
        CancelInvoke("endWave");
        isWaveOn = false;
        Debug.Log("Wave " + currentWaveNum + " Ended");
        // prepare the next wave or prepare for the mighty boss
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

    public void ShowMsg(string msg)
    {
        if (!MsgTXT.IsActive())
        {
            MsgTXT.text = msg;
            MsgTXT.gameObject.SetActive(true);
        }
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
