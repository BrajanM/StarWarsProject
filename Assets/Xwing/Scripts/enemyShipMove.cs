using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShipMove : MonoBehaviour {




    public GameObject explosion;
    public Transform enemyship;
	// Use this for initialization
	void Start ()
    {
       
	}
	
	// Update is called once per frame
	void Update ()
    {
        float speed = ShipSpawner.Speed;
        
        transform.Translate(new Vector3(0,1,0)*speed*Time.deltaTime);


	}
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Destroy(gameObject);
        UIMenager.Score++;
        Instantiate(explosion,enemyship.position,transform.rotation=Quaternion.identity);
    }
}
