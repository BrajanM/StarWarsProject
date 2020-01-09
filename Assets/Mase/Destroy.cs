using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroy : MonoBehaviour
{
    public GameObject e8;
    public static int deaths;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(e8, other.transform.position, Quaternion.identity);
        Destroy(other.gameObject);
        deaths++;
        
        switch (SceneManager.GetActiveScene().name)
        {
            case "scene1":
                SceneManager.LoadScene("scene1");
                break;
            case "scene2":
                SceneManager.LoadScene("scene2");
                break;
            case "scene3":
                SceneManager.LoadScene("scene3");
                break;
            case "scene4":
                SceneManager.LoadScene("scene4");
                break;
            case "scene5":
                SceneManager.LoadScene("scene5");
                break;
            case "scene6":
                SceneManager.LoadScene("scene6");
                break;
        }
    }
}



