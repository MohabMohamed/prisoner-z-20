using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour {


    public int CurrentScore;
    public TextMeshProUGUI ScoreText;

    void Update()
    {
        ScoreText.text = "Score: " + CurrentScore;
    }

    public void addScore(int num)
    {
        CurrentScore += num;
    }
    public int getScore()
    {
        return CurrentScore;
    }

}
