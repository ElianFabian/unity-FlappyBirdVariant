using Assets.Scripts.Util;
using System;
using UnityEngine;



[DisallowMultipleComponent]
public class GameManager : SingletonPersistent<GameManager>
{
    public event Action      OnGameOver;
    public event Action<int> OnScoreChanged;

    int score;



    private void Start()
    {
        OnGameOver -= SetGameOver;

        score = 0;
    }

    public void IncrementScore()
    {
        score++;

        OnScoreChanged?.Invoke(score);
    }

    public void SetGameOver()
    {
        OnGameOver?.Invoke();
    }
}
