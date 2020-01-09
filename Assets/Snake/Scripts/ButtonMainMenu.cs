using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonMainMenu : MonoBehaviour {

    public void ButtonMainMenu_Click()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
