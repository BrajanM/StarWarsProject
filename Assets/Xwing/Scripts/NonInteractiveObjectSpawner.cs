using UnityEngine;
using System.Collections;

public class NonInteractiveObjectSpawner : MonoBehaviour
{

    public GameObject[] NIObject;

    
    public float delayTime = 1f;

    public float[] pozitions;
    int objectNo;
    float timer;
    float timer2;
    public float delayTime2 = 1.5f;
    int pozNo;



    static float speed = -5f;
    public static float Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    // Use this for initialization
    void Start()
    {

        timer = delayTime;
        timer2 = delayTime2;

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timer2 -= Time.deltaTime;
        if (timer <= 0)
        {



            pozNo = Random.Range(0, pozitions.Length);
            Vector3 ShipPoz = new Vector3(pozitions[pozNo], transform.position.y, transform.position.z);
            objectNo = Random.Range(0, NIObject.Length);
            Instantiate(NIObject[objectNo], ShipPoz, transform.rotation);
            timer = delayTime;
        }


    }
}
