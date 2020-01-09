using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;
using UnityEngine.UI;

public class Slug : MonoBehaviour
{

    private enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }
    private enum State
    {
        Alive,
        Dead
    }

    private State state;
    private Vector2Int gridPosition;
    private Direction gridMoveDirection;
    private LevelGrid levelGrid;
    public float gridMoveTimer;
    public float gridMoveTimerMax;
    private int slugBodySize;
    private List<SlugMovePosition> slugMovePositionList;
    private List<SlugBodyPart> slugBodyPartList;

    public void Setup(LevelGrid levelGrid)
    {
        this.levelGrid = levelGrid;
    }
    private void Awake() //spr
    {
        gridPosition = new Vector2Int(10, 10);
        gridMoveTimerMax = 0.25f;
        gridMoveTimer = gridMoveTimerMax;
        gridMoveDirection = Direction.Right;
        slugMovePositionList = new List<SlugMovePosition>();
        slugBodySize = 0;
        slugBodyPartList = new List<SlugBodyPart>();
        state = State.Alive;

    }
    private void Update() //spr
    {
        switch (state)
        {
            case State.Alive:
                HandleInput();
                HandleGridMovement();
                break;
            case State.Dead:
                break;
        }
        
    }

    private void HandleInput() //spr
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (gridMoveDirection != Direction.Down)
            {
                gridMoveDirection = Direction.Up;
            }

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (gridMoveDirection != Direction.Up)
            {
                gridMoveDirection = Direction.Down;
            }

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (gridMoveDirection != Direction.Right)
            {
                gridMoveDirection = Direction.Left;
            }

        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (gridMoveDirection != Direction.Left)
            {
                gridMoveDirection = Direction.Right;
            }

        }
    }

    
    private void HandleGridMovement() //spr
    {
        gridMoveTimer += Time.deltaTime;
        if (gridMoveTimer >= gridMoveTimerMax)
        {

            gridMoveTimer -= gridMoveTimerMax;

            SlugMovePosition previousSlugMovePosition = null;
            if (slugMovePositionList.Count > 0)
            {
                previousSlugMovePosition = slugMovePositionList[0];
            }
            SlugMovePosition slugMovePosition = new SlugMovePosition(previousSlugMovePosition, gridPosition, gridMoveDirection);
            slugMovePositionList.Insert(0, slugMovePosition);

            Vector2Int gridMoveDirectionVector;
            switch (gridMoveDirection)
            {
                default:
                case Direction.Right: gridMoveDirectionVector = new Vector2Int(+1, 0); break;
                case Direction.Left: gridMoveDirectionVector = new Vector2Int(-1, 0); break;
                case Direction.Up: gridMoveDirectionVector = new Vector2Int(0, +1); break;
                case Direction.Down: gridMoveDirectionVector = new Vector2Int(0, -1); break;

            }
            
            gridPosition += gridMoveDirectionVector;
            gridPosition = levelGrid.ValidateGridPosition(gridPosition);

            bool slugAteFood = levelGrid.TrySlugEatFood(gridPosition); 
            if (slugAteFood)
            {
                slugBodySize++;
                CreateSlugBodyPart();
                Score.scoreValue += 10; // DODAWANIE PUNKTÓW
                if(Score.scoreValue == 150)
                {
                    CMDebug.TextPopup("Next level!", transform.position);
                    gridMoveTimerMax = 0.20f;
                }
                else if(Score.scoreValue == 250)
                {
                    CMDebug.TextPopup("Next level!", transform.position);
                    gridMoveTimerMax = 0.15f;
                }
                else if(Score.scoreValue == 350)
                {
                    CMDebug.TextPopup("Next level!", transform.position);
                    gridMoveTimerMax = 0.10f;
                }
                else if(Score.scoreValue == 450)
                {
                    CMDebug.TextPopup("Next level!", transform.position);
                    gridMoveTimerMax = 0.05f;
                }
            }



            if (slugMovePositionList.Count >= slugBodySize + 1)
            {
                slugMovePositionList.RemoveAt(slugMovePositionList.Count - 1);
            }

            //for (int i = 0; i < slugMovePositionList.Count; i++)
            //{
            //    Vector2Int slugMovePosition = slugMovePositionList[i];
            //    World_Sprite worldSprite = World_Sprite.Create(new Vector3(slugMovePosition.x, slugMovePosition.y), Vector3.one * .5f, Color.white);
            //    FunctionTimer.Create(worldSprite.DestroySelf, gridMoveTimerMax);
            //}

            UpdateSlugBodyParts();
            foreach (SlugBodyPart slugBodyPart in slugBodyPartList)
            {
                Vector2Int slugBodyPartGridPosition = slugBodyPart.GetGridPosition();
                if (gridPosition == slugBodyPartGridPosition)
                {
                    
                    //CMDebug.TextPopup("DEAD!", transform.position);
                    CMDebug.TextPopup("DEAD!", transform.position);
                    state = State.Dead;
                    PlayerPrefs.SetInt("Player Score", Score.scoreValue);
                    //PlayerPrefs.Save();
                    //print(PlayerPrefs.GetInt("Player Score"));
                }
            }


            transform.position = new Vector3(gridPosition.x, gridPosition.y);
            transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(gridMoveDirectionVector) - 90);

           



        }


    }


    //private void CreateSlugBody()
    //{
    //    GameObject slugBodyGameObject = new GameObject("SlugBody", typeof(SpriteRenderer));
    //    slugBodyGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.instance.SlugBodySprite;

    //    slugBodyTransformList.Add(slugBodyGameObject.transform);
    //    slugBodyGameObject.GetComponent<SpriteRenderer>().sortingOrder = -slugBodyTransformList.Count;
    //}


    private void CreateSlugBodyPart() //spr
    {
        slugBodyPartList.Add(new SlugBodyPart(slugBodyPartList.Count));
    }


    private void UpdateSlugBodyParts()
    {
        for (int i = 0; i < slugBodyPartList.Count; i++)
        {

            slugBodyPartList[i].SetSlugMovePosition(slugMovePositionList[i]);
        }
    }



    private float GetAngleFromVector(Vector2Int dir)
    {
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;



        return n;
    }
    public Vector2Int GetGridPosition()
    {
        return gridPosition;
    }
    public List<Vector2Int> GetFullSlugGridPositionList()
    {
        List<Vector2Int> gridPositionList = new List<Vector2Int>() { gridPosition };

        foreach (SlugMovePosition slugMovePosition in slugMovePositionList)
        {
            gridPositionList.Add(slugMovePosition.GetGridPosition());
        }

        return gridPositionList;
    }

    private class SlugBodyPart
    {
        private SlugMovePosition slugMovePosition;
        //private Vector2Int gridPosition;
        private Transform transform;

        public SlugBodyPart(int bodyIndex) //spr
        {
            GameObject slugBodyGameObject = new GameObject("SlugBody", typeof(SpriteRenderer));
            slugBodyGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.instance.SlugBodySprite;
            slugBodyGameObject.GetComponent<SpriteRenderer>().sortingOrder = -bodyIndex;
            transform = slugBodyGameObject.transform;
        }
        public void SetSlugMovePosition(SlugMovePosition slugMovePosition) //spr
        {
            this.slugMovePosition = slugMovePosition;
            transform.position = new Vector3(slugMovePosition.GetGridPosition().x, slugMovePosition.GetGridPosition().y);
            float angle;
            switch (slugMovePosition.GetDirection())
            {
                default:
                case Direction.Up:
                    switch (slugMovePosition.GetPreviousDirection())
                    {
                        default: angle = 0; break;
                        case Direction.Left: angle = 0 + 45;
                            transform.position += new Vector3(.2f, .2f);
                            break;
                        case Direction.Right: angle = 0 - 45;
                            transform.position += new Vector3(.2f, -.2f);
                            break;
                    }
                    break;
                case Direction.Down:
                    switch (slugMovePosition.GetPreviousDirection())
                    {
                        default: angle = 180; break;
                        case Direction.Left: angle = 180 + 45;
                            transform.position += new Vector3(.2f, .2f);
                            break;
                        case Direction.Right: angle = 180 - 45;
                            transform.position += new Vector3(.2f, -.2f);
                            break;
                    }
                    break;
                case Direction.Left:
                    switch (slugMovePosition.GetPreviousDirection())
                    {
                        default: angle = -90; break;
                        case Direction.Down: angle = -45;
                            transform.position += new Vector3(.2f, .2f);
                            break;
                        case Direction.Up: angle = 45;
                            transform.position += new Vector3(.2f, -.2f);
                            break;
                    }
                    break;
                case Direction.Right:
                    switch (slugMovePosition.GetPreviousDirection())
                    {
                        default: angle = 90; break;
                        case Direction.Down: angle = 45;
                            transform.position += new Vector3(.2f, .2f);
                            break;
                        case Direction.Up: angle = -45;
                            transform.position += new Vector3(.2f, -.2f);
                            break;
                    }
                    break;
            }
            transform.eulerAngles = new Vector3(0, 0, angle);
        }

        public Vector2Int GetGridPosition()
        {
            return slugMovePosition.GetGridPosition();
        }
    }

    private class SlugMovePosition
    {
        private SlugMovePosition previousSlugMovePosition;
        private Vector2Int gridPosition;
        private Direction direction;

        public SlugMovePosition(SlugMovePosition previousSlugMovePosition, Vector2Int gridPosition, Direction direction)
        {
            this.previousSlugMovePosition = previousSlugMovePosition;
            this.gridPosition = gridPosition;
            this.direction = direction;
        } //spr

        public Vector2Int GetGridPosition() //spr
        {
            return gridPosition;
        }

        public Direction GetDirection() //spr
        {
            return direction;
        }

        public Direction GetPreviousDirection()
        {
            if (previousSlugMovePosition == null)
            {
                return Direction.Right;
            }
            else
            {
                return previousSlugMovePosition.direction;
            }

        }
    }

}
