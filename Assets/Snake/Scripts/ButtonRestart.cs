using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonRestart : MonoBehaviour {

    public void Button_Click()
    {
        Application.LoadLevel(Application.loadedLevel);
        Score.scoreValue = 0;   
    }
    
}
