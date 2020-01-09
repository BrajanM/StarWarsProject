using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GameTimer
{

    public Text TimerDisplay;
    private float timeCounter{ get; set; }
    public float minusLifeTime = 2f;
    public float minusLifeTimeCounter = 0f;

    public GameTimer(float newTime = 30f) {
        SetNewTime(newTime);
    }

    public void SetNewTime(float newTime = 30f){
        timeCounter = newTime;
        }
    public void UpdateTimer()
    {
        timeCounter -= Time.deltaTime;
        if (timeCounter >= 0)
            TimerDisplay.text = timeCounter.ToString("F");
        else
            TimerDisplay.text = "0";
    }
    public float GetTimerCounter() {
        return timeCounter;
    }
    public bool IsZero() {
        if (timeCounter <= 0)
            return true;
        else return false;
    }

}
