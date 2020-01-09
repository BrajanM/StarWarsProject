using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Linq;
public class GameMenuManager : MonoBehaviour
{

    
    public Button[] buttons;


    // Use this for initialization
    void Start()
    {
        ButtonActivating();
    }

    // Update is called once per frame
    void Update()
    {
        ButtonActivating();


    }

    public void Play()
    {

        Application.LoadLevel("lvl1");
        



    }
    public void Exit()
    {

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