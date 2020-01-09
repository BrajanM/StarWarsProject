using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid  {


    private Vector2Int foodGridPosition;
    private GameObject foodGameObject;
    private int width;
    private int height;
    private Slug slug;


    public LevelGrid(int width,int hight)
    {
        this.width = width;
        this.height = hight;

        
    }
    public void Setup(Slug slug)
    {
        this.slug = slug;
        
        SpawnFood();
    }
    private void SpawnFood()
    {
        do
        {
            foodGridPosition = new Vector2Int(Random.Range(0, width), Random.Range(0, height));
        } while (slug.GetGridPosition()==foodGridPosition);

        foodGameObject = new GameObject("Food", typeof(SpriteRenderer));
        foodGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.instance.FoodSprite;
        foodGameObject.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y);
    }

    public bool TrySlugEatFood(Vector2Int slugGridPosition)
    {
        if (slugGridPosition==foodGridPosition)
        {
            Object.Destroy(foodGameObject);
            SpawnFood();
            
            return true;
        }
        else
        {
            return false;
        }
    }

    public Vector2Int ValidateGridPosition(Vector2Int gridPosition)
    {
        if(gridPosition.x < 0)
        {
            gridPosition.x = width - 1;
        }
        if (gridPosition.x > width - 1)
        {
            gridPosition.x = 0;
        }
        if (gridPosition.y < 0)
        {
            gridPosition.y = height - 1;
        }
        if (gridPosition.y > height - 1)
        {
            gridPosition.y = 0;
        }
        return gridPosition;
    }
	
}
