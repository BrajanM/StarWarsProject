using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackMove : MonoBehaviour {


    public float speed;
    Vector3 offset;
   
	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (UIMenager.gameOver==false)
        {

            offset = new Vector3(0, Time.timeSinceLevelLoad* speed,0);
            GetComponent<Renderer>().material.mainTextureOffset = offset;

        }
        else
        {
            
            GetComponent<Renderer>().material.mainTextureOffset = offset;
        }

    }
}
