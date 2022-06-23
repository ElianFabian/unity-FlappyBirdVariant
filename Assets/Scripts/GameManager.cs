using Assets.Scripts.Util;
using System;
using UnityEngine;


[DisallowMultipleComponent]
public class GameManager : SingletonPersistent<GameManager>
{
    public event Action OnGameOver;
    public event Action<int> OnIncrementScore;

    int score;



    private void Awake()
    {
        OnGameOver -= SetGameOver;
        score = 0;
    }

    public void IncrementScore()
    {
        score++;

        OnIncrementScore?.Invoke(score);
    }

    public void SetGameOver()
    {
        OnGameOver?.Invoke();
    }
}
