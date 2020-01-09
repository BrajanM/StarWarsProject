using UnityEngine;
using System.Collections;

public class GeneratorAnimationControler : MonoBehaviour
{
    public Animator anim;
    public GameObject ship;
    public static int GeneratorHealth;
    public static int GeneratorHittedTimes;

    private int frameTime;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
        GeneratorHealth = 8;
        GeneratorHittedTimes = 8;
    }

    // Update is called once per frame
    void Update()
    {
        if (GeneratorHealth<8)
        {
            // anim.Play("GeneratorState", 0, 0f);
            anim.enabled = true;
            GeneratorHealth =8;

            frameTime = 8;
        }


        if (frameTime<=0)
        {
            anim.enabled = false;
        }
        frameTime -= 1;
        if (GeneratorHittedTimes<=0)
        {
            Destroy(ship);
            UIMenager.gameOver = true;
        }

    }
}
