using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Linq;
public class UIMenager : MonoBehaviour {

    public static bool gameOver = false;

    

    public Text scoreText;
    public Text TimeText;
    static int score;
    static float startTime;
    public static float StartTime;
    public static int Score
    {
        get { return score; }
        set { score = value; }
    }


    string EndTime;
    string EndScore;


    public Button[] buttons;

    public List<string> Results;
   


	// Use this for initialization
	void Start ()
    {
        score = 0;
        TimeText.text = "00:00";
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
    {

      

        if (gameOver==false)
        {
            float t = Time.time - startTime;
            string minutes = ((int)t / 60).ToString("f0");
            string seconds = (t % 60).ToString("f2");
            TimeText.text ="Time: "+ minutes + ":" + seconds;
            EndTime= "Time: "+minutes + ":" + seconds;
            scoreText.text = "Score: " + score;
            EndScore= "Score: " + score;
        }
        else
        {
            scoreText.text = EndScore;
            TimeText.text = EndTime;
            ButtonActivating();


            if (Results.Count==0)
            {
                string result = EndScore + ";" + EndTime + ";";
                Results.Add(result);

            }
            else
            {
                if ((EndScore + ";" + EndTime + ";") != Results[Results.Count - 1])
                {
                    string result = EndScore + ";" + EndTime + ";";
                    Results.Add(result);
                }
            }

        }

        if (score==10)
        {
            GeneralStats.XwingScore = score;
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name=="lvl1")
            {
                SceneManager.LoadScene("lvl2_Hoth");
            }
        }
        


    }

    public void Replay()
    {


        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);


        gameOver = false;
        ShipSpawner.Speed = -5f;

        

    }
    public void Exit()
    {
        

        StreamWriter writer = new StreamWriter("results.txt");
        foreach (string result in Results)
        {
            writer.WriteLine(result+"\r\n");
        }
        writer.Close();
        GeneralStats.XwingScore += score;
        SceneManager.LoadScene("MainGameMenu");

    }
    void ButtonActivating()
    {
        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(true);
        }
    }

}
