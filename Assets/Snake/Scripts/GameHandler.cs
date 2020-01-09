using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour {

    [SerializeField] private Slug slug;
    private LevelGrid levelGrid;
    
   
	void Start () {
        Debug.Log("Gamehandler.Start");
        levelGrid = new LevelGrid(30,19);
        slug.Setup(levelGrid);
        levelGrid.Setup(slug);

    }
}
