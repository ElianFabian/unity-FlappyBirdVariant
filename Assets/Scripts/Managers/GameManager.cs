using Assets.Scripts.Util;
using System;
using UnityEngine;



[DisallowMultipleComponent]
public class GameManager : SingletonPersistent<GameManager>
{
    [SerializeField] KeyCode pauseKey = KeyCode.Escape;

    public event Action      OnGameOver;
    public event Action      OnGamePaused;
    public event Action      OnGameResumed;
    public event Action<int> OnScoreChanged;

    int score;
    bool isGamePaused = false;



    private void Start()
    {
        OnGameOver -= SetGameOver;

        score = 0;
    }

    private void Update()
    {
        if (!Input.GetKeyDown(pauseKey)) return;

        isGamePaused = !isGamePaused;

        if (isGamePaused)
        {
            Pause();
            OnGamePaused?.Invoke();
        }
        else
        {
            Resume();
            OnGameResumed?.Invoke();
        }
    }

    public void IncrementScore()
    {
        score++;

        OnScoreChanged?.Invoke(score);
    }

    public void SetGameOver()
    {
        Pause();

        OnGameOver?.Invoke();
    }

    void Pause()
    {
        Time.timeScale = 0;
    }

    void Resume()
    {
        Time.timeScale = 1;
    }
}
