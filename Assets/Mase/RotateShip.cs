using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateShip : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            transform.Rotate(0, 0, 90);
        } else if (Input.GetKeyDown("e"))
        {
            transform.Rotate(0, 0, -90);
        }
    }
}
