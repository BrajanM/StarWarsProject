using UnityEngine;
using System.Collections;

public class atatMove : MonoBehaviour
{

    public GameObject explosion;
    public Transform enemyship;
    public float speed;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

        transform.Translate(new Vector3(0, -1, 0) * speed);


    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        if (hitInfo.gameObject.tag == "ShipLaser")
        {
            


            UIMenager.Score++;
        }
        Destroy(gameObject);
        Instantiate(explosion, enemyship.position, transform.rotation = Quaternion.identity);
    }
}

