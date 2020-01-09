using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    ScoreManager _scoreManager;
    TimeCounter _timeCounter;
    public void RestartGame()
    {
        _scoreManager = FindObjectOfType<ScoreManager>();
        _timeCounter = FindObjectOfType<TimeCounter>();
        string result = DateTime.Now + ", score: " + _scoreManager.score + ", time: " + _timeCounter.timeCounted;
        if (File.Exists("results.txt"))
        {
            File.AppendAllText("results.txt", result);
        }
        else
        {
            StreamWriter writer = new StreamWriter("results.txt");
            writer.WriteLine(result + "\r\n");
            writer.Close();
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}