using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xwingControler : MonoBehaviour {

    

    public float xwingSpeed;
    public float maxPos=8.5f;
    public float minPos =-7.9f;
    Vector3 position;

	// Use this for initialization
	void Start ()
    {
        position = transform.position;

		
	}
	
	// Update is called once per frame
	void Update ()
    {
        position.x += Input.GetAxis("Horizontal") * xwingSpeed * Time.deltaTime;

        position.x = Mathf.Clamp(position.x, maxPos, minPos);

        transform.position = position;



	}



    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag=="Enemy_Ship")
        {
            Destroy(gameObject);
            UIMenager.gameOver = true;
        }
        if (col.gameObject.tag == "EnemyLaser")
        {
            Destroy(gameObject);
            UIMenager.gameOver = true;
        }
    }
}
