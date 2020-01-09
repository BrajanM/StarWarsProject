using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Project based on
// theflyingkeyboard.net

public class CardController : MonoBehaviour
{
    [SerializeField]
    private string _cardName; 

    private bool _isUpsideDown = false; 

    private Sprite _backSideCardSprite; 

    [SerializeField]
    private Sprite _frontSideCardSprite; 

    private SpriteRenderer _spriteRenderer;
    private GameManager _gameManager;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _gameManager = FindObjectOfType<GameManager>();

        _backSideCardSprite = _spriteRenderer.sprite;
    }

    public string cardName
    {
        get
        {
            return _cardName;
        }
        set
        {
            _cardName = value;
        }
    }

    private void OnMouseDown() 
    {
        if (!_isUpsideDown)
        {
            _gameManager.AddCard(gameObject);
            ChangeSide();
        }
    }

    public void ChangeSide()
    {
        if (!_isUpsideDown)
        {
            _spriteRenderer.sprite = _frontSideCardSprite;
            _isUpsideDown = true;
        }
        else
        {
            _spriteRenderer.sprite = _backSideCardSprite;
            _isUpsideDown = false;
        }
    }
}