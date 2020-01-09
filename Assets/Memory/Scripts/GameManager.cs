using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject _firstCard = null;
    private GameObject _secondCard = null;

    private int _cardsLeft;

    private bool _canFlip = true;

    [SerializeField]
    private float _timeBetweenFlips = 0.5f; 

    private ScoreManager _scoreManager; 
    [SerializeField]
    private GameObject _winMenu; 
    [SerializeField]
    private TimeCounter _timeCounter;

    public bool canFlip
    {
        get
        {
            return _canFlip;
        }
        set
        {
            _canFlip = value;
        }
    }

    public int cardsLeft
    {
        get
        {
            return _cardsLeft;
        }
        set
        {
            _cardsLeft = value;
        }
    }

    void Start()
    {
        _scoreManager = FindObjectOfType<ScoreManager>(); 
        _timeCounter = FindObjectOfType<TimeCounter>();
        Object[] cards = CardController.FindObjectsOfType(typeof(GameObject));
        

    }

    public void AddCard(GameObject card) 
    {
        
        if (_firstCard == null) 
        {
            _firstCard = card;
        }
        else
        {
            _secondCard = card;
            _canFlip = false;

            if (CheckIfMatch())
            {
                DecreaseCardCount();

                _scoreManager.AddScore(); 
                _scoreManager.AddScore(); 

                StartCoroutine(DeactivateCards());
            }
            else
            {
                StartCoroutine(FlipCards());
            }
        }
    }

    IEnumerator DeactivateCards()
    {
        yield return new WaitForSeconds(_timeBetweenFlips);
        _firstCard.SetActive(false);
        _secondCard.SetActive(false);

        Reset();
    }

    IEnumerator FlipCards()
    {
        yield return new WaitForSeconds(_timeBetweenFlips); 
        _firstCard.GetComponent<CardController>().ChangeSide();
        _secondCard.GetComponent<CardController>().ChangeSide();

        Reset();
    }

    public void Reset()
    {
        _firstCard = null;
        _secondCard = null;

        _canFlip = true;
    }

    public void DecreaseCardCount()
    {
        _cardsLeft -= 2;

        if (_cardsLeft <= 0)
        {
            _winMenu.SetActive(true); 
            _timeCounter.countTime = false;
        }
    }

    bool CheckIfMatch()
    {
        if (_firstCard.GetComponent<CardController>().cardName == _secondCard.GetComponent<CardController>().cardName)
        {
            return true;
        }

        return false;
    }
}