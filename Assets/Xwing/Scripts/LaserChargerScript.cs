using UnityEngine;
using System.Collections;

public class LaserChargerScript : MonoBehaviour
{
    public Animator anim;
    public float shootTime = 0;
    public float minShootTime = 120;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        //anim.Play("LaserChargerInfo");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (shootTime >= minShootTime)
            {
                anim.Play("LaserCharging", 0, 0f);

                shootTime = 0;

            }
        }
        shootTime += 1;
    }
}
