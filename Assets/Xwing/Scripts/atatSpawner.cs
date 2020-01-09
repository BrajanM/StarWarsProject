using UnityEngine;
using System.Collections;

public class atatSpawner : MonoBehaviour
{

    public GameObject[] ATAT;

    public float maxPos = 8.5f;
    public float minPos = -7.9f;
    public float delayTime = 1f;

    public float[] pozitions = new float[7] { -11f,-7f, -3f, 0f, 3f, 8.5f,10f };
    int shipNo;
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



            pozNo = Random.Range(0, 7);
            Vector3 ShipPoz = new Vector3(pozitions[pozNo], transform.position.y, transform.position.z);
            shipNo = Random.Range(0, 3);
            Instantiate(ATAT[shipNo], ShipPoz, transform.rotation);
            timer = delayTime;
        }
        

    }
}
