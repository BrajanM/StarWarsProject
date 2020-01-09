using UnityEngine;
using System.Collections;

public class GeneratorProgres : MonoBehaviour
{
   
    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy_Ship")
        {
            Destroy(col.gameObject);

            GeneratorAnimationControler.GeneratorHealth += -1;
            GeneratorAnimationControler.GeneratorHittedTimes -= 1;

        }
        if (col.gameObject.tag == "NIObject")
        {
            Destroy(col.gameObject);


        }
        if (col.gameObject.tag == "EnemyLaser")
        {
            Destroy(col.gameObject);


        }

    }
}
