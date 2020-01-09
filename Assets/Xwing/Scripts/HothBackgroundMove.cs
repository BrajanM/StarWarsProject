using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HothBackgroundMove : MonoBehaviour {
    public float speed;
    Vector3 startPOS;
	// Use this for initialization
	void Start () {
        startPOS = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate((new Vector3(0,-1,0))*speed);

        if (transform.position.y < startPOS.y - 21.999)
        {
            transform.position = startPOS;
        }

        //-22.049
        //5
    }

}
