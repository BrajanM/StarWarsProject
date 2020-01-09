using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonExit : MonoBehaviour {

    public void ButtonExit_Click()
    {
        SceneManager.LoadScene("MainGameMenu");
        GeneralStats.SnakeScore = Score.scoreValue;

    }

}
