using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _score = 0;

    [SerializeField]
    private int _scorePerCard = 50;

    private TimeCounter _timeCounter;
    private ScoreCounter _scoreCounter;

    public int score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
        }
    }

    void Start()
    {
        _timeCounter = FindObjectOfType<TimeCounter>();
        _scoreCounter = FindObjectOfType<ScoreCounter>();
    }

    public void AddScore()
    {
        _score += _scorePerCard;
    }
}