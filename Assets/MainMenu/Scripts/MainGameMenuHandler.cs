using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Linq;
public class MainGameMenuHandler : MonoBehaviour
{
    
    public Button[] buttons;
    public string[] scenes= {"Xmenu","menuScene","Xmenu","scene1","SampleScene"};
    public int sceneNumber = 0;
    public Animator[] animations;
    public Text LevelName;
    public Image LevelIcon;
    public Sprite[] Icons;
    public string[] levelNames = { "Zwinność Jedi", "Wiedza Jedi", "Taktyka Jedi", "Precyzja Jedi", "Pamięć Jedi" };

    // Use this for initialization
    void Start()
    {



        LevelName.text = levelNames[0];
        LevelIcon.sprite = Icons[0];




    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Exit()
    {

        Application.Quit();

    }
    public void Play()
    {
        SceneManager.LoadScene(scenes[sceneNumber]);

    }


    public void NextScene()
    {
        sceneNumber += 1;
        if (sceneNumber >=levelNames.Length)
        {
            sceneNumber = 0;
        }
        animations[0].Play("HoloSpinAnim", 0);
        LevelName.text = levelNames[sceneNumber];
        LevelIcon.sprite = Icons[sceneNumber];
    }



    public void PrevScene()
    {
        sceneNumber -= 1;
        if (sceneNumber < 0)
        {
            sceneNumber = levelNames.Length-1;
        }
        animations[1].Play("HoloSpinLeftAnim",0);
        LevelName.text = levelNames[sceneNumber];
        LevelIcon.sprite = Icons[sceneNumber];
    }
    public void StatView()
    {
        SceneManager.LoadScene("StatView");
    }
}
