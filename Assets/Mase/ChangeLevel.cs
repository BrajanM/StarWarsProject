using Assets;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    static MazeTimeCounter mazeTimeCounter;

    // Start is called before the first frame update
    void Start()
    {
        mazeTimeCounter = new MazeTimeCounter();
        mazeTimeCounter.StartTime = Time.time;
    }

    private void OnTriggerEnter(Collider other)
    {
        GeneralStats.MazeScore = mazeTimeCounter.OverallTime;
        switch (SceneManager.GetActiveScene().name)
        {
            case "scene1":
                mazeTimeCounter.FirstLevelTime = Time.time - mazeTimeCounter.StartTime;
                SceneManager.LoadScene("scene2");
                break;
            case "scene2":
                mazeTimeCounter.SecondLevelTime = Time.time - mazeTimeCounter.StartTime;
                SceneManager.LoadScene("scene3");
                break;
            case "scene3":
                mazeTimeCounter.ThirdLevelTime = Time.time - mazeTimeCounter.StartTime;
                SceneManager.LoadScene("scene4");
                break;
            case "scene4":
                mazeTimeCounter.FourthLevelTime = Time.time - mazeTimeCounter.StartTime;
                SceneManager.LoadScene("scene5");
                break;
            case "scene5":
                mazeTimeCounter.FifthLevelTime = Time.time - mazeTimeCounter.StartTime;
                SceneManager.LoadScene("scene6");
                break;
            case "scene6":
                mazeTimeCounter.SixthLevelTime = Time.time - mazeTimeCounter.StartTime;
                SceneManager.LoadScene("MainGameMenu");
                break;
                
        }
    }
}
