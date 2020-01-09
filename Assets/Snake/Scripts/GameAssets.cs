using UnityEngine;
using System.Collections;

public class GameAssets : MonoBehaviour
{
  
    public static GameAssets instance;
    private void Awake()
    {
        instance = this;
    }
    public Sprite SlugHeadSprite;
    public Sprite FoodSprite;
    public Sprite SlugBodySprite;

}
