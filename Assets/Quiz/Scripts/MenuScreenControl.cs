using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScreenControl : MonoBehaviour
{

    public void StartGame()
    {
        ScoreControl.scoreCounter= 0;
        LifeControl.LifeCounter = 5;
        SceneManager.LoadScene("Game");
    }

    public void ExitFromQuiz()
    {
        SceneManager.LoadScene("MainGameMenu");
    }
}