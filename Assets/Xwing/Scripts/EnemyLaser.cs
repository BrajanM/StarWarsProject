using UnityEngine;
using System.Collections;

public class EnemyLaser : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb.velocity = transform.up * speed * -1;
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Destroy(gameObject);
    }


}