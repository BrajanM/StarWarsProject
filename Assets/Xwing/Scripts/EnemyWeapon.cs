using UnityEngine;
using System.Collections;

public class EnemyWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject prefab;
    public float shootTime = 0;
    public float minShootTime = 120;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

     
            if (shootTime >= minShootTime)
            {
                Shoot();
                shootTime = 0;

            }

        
        shootTime += 1;

    }
    void Shoot()
    {
        Instantiate(prefab, firePoint.position, firePoint.rotation);


    }
}

