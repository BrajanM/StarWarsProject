using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour {




	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag=="Enemy_Ship")
        {
            Destroy(col.gameObject);


            UIMenager.Score++;
        }
        if (col.gameObject.tag == "NIObject")
        {
            Destroy(col.gameObject);

           
        }
    }
}
