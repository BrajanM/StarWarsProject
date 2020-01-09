using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class LifeControl {

    public Text lifeDisplay;
    public static int LifeCounter = 5;

    public void DecrementLifeCounter()
    {
        LifeCounter--;
        UpdateLifeDisplay();
        
    }

    public void UpdateLifeDisplay()
    {
        lifeDisplay.text = "";
        for (int i = 0; i < LifeCounter; i++)
        {
            lifeDisplay.text += "b";
        }
    }

    public void IncrementLife() {
        LifeCounter++;
        UpdateLifeDisplay();
    }
}
