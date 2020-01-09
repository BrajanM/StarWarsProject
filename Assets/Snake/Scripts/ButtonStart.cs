using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonStart : MonoBehaviour {
  
    public void ButtonStart_Click()
    {
        SceneManager.LoadScene("GameScene");
    }

}
