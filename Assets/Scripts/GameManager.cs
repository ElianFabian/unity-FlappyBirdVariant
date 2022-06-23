using Assets.Scripts.Util;
using System;
using UnityEngine;


[DisallowMultipleComponent]
public class GameManager : SingletonPersistent<GameManager>
{
    public Action OnGameOver;
    public Action<int> OnIncrementScore;

    int score;

    private void Awake()
    {

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
