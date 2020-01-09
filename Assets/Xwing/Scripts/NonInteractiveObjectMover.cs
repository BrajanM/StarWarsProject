using UnityEngine;
using System.Collections;

public class NonInteractiveObjectMover : MonoBehaviour
{
    public float speed;
    public float pozitionToDelete;
    Vector3 startPOS;
    // Use this for initialization
    void Start()
    {
        startPOS = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((new Vector3(0, -1, 0)) * speed );

        if (transform.position.y<=pozitionToDelete)
        {
            Destroy(gameObject);
        }


    }
}
