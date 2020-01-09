using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ScoreControl 
{
    public Text scoreDisplay;
    public static int scoreCounter=0;

    public void AddAndUpdate(int pointsForQuestion = 10) {
        scoreCounter += pointsForQuestion;
        UpdateScoreDisplay();
    }

    public void UpdateScoreDisplay() {
        scoreDisplay.text = scoreCounter.ToString();
    }

    public void ZerosScore()
    {
        scoreCounter = 0;
    }
    
}
