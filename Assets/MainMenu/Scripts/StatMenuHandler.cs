using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Linq;
public class StatMenuHandler : MonoBehaviour
{
    public Sprite[] orders;
    public string[] rangs= {"Padawan","Rycerz Jedi","Mistrz Jedi","Wcielona Moc"};
    public Text Zwinnosc;
    public Text Pamiec;
    public Text Taktyka;
    public Text Wiedza;
    public Text Precyzja;
    public Text Suma;
    public Text Ranga;
    public Image OrderImage;
    public double[] steps = {0,100,200,300};
    public Button[] buttons;
    // Use this for initialization
    void Start()
    {
        Pamiec.text = GeneralStats.MemoryScore.ToString();
        Zwinnosc.text = GeneralStats.XwingScore.ToString();
        Precyzja.text = GeneralStats.MazeScore.ToString();
        Taktyka.text = GeneralStats.SnakeScore.ToString();
        Wiedza.text = GeneralStats.QuizScore.ToString();

        double suma = GeneralStats.MemoryScore + GeneralStats.XwingScore + GeneralStats.MazeScore + GeneralStats.SnakeScore + GeneralStats.QuizScore;
        Suma.text = suma.ToString();

        if (suma>=steps[0]&&suma<steps[1])
        {
            Ranga.text = rangs[0];
            OrderImage.sprite = orders[0];
        }
        if (suma >= steps[1] && suma < steps[2])
        {
            Ranga.text = rangs[1];
            OrderImage.sprite = orders[1];
        }
        if (suma >= steps[2] && suma < steps[3])
        {
            Ranga.text = rangs[2];
            OrderImage.sprite = orders[2];
        }
        if (suma >= steps[3])
        {
            Ranga.text = rangs[3];
            OrderImage.sprite = orders[3];
        }
        

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MenuEnter()
    {
        SceneManager.LoadScene("MainGameMenu");
    }
    public void Exit()
    {
        Application.Quit();
       
    }
}
