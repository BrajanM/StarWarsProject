using UnityEngine;
using System.Collections;

public class ExplosionDestroyer : MonoBehaviour
{
    public float destroyTime = 2.0f;
    // Use this for initialization
    private void FixedUpdate()
    {
        Destroy(gameObject, destroyTime);
    }
}
