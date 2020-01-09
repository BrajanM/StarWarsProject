using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssetsMainMenu : MonoBehaviour {

    public static GameAssetsMainMenu instance1;
    private void Awake()
    {
        instance1 = this;
    }
}
