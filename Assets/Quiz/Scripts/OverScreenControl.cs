using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OverScreenControl : MonoBehaviour
{
    [SerializeField]
    public Text ScoreDisplay;

    private void Start()
    {
        ScoreDisplay.text = ScoreControl.scoreCounter.ToString();
    }    

    public void BackToMenu()
    {
        SceneManager.LoadScene("menuScene");
    }
    public void ExitFromQuiz()
    {
        SceneManager.LoadScene("MainMenu");
        GeneralStats.QuizScore = ScoreControl.scoreCounter;
    }
}