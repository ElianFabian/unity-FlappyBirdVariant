using Assets.Scripts.Util;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts.PipeScripts;
using Assets.Scripts.PlayerScripts;



// To make the Game Manager work properly I had to added to the
// Script Execution Order settings.
[DisallowMultipleComponent]
public class GameManager : SingletonPersistent<GameManager>
{
    [SerializeField] KeyCode _pauseKey = KeyCode.Escape;

    public event Action         OnGameOver;
    public event Action         OnGamePaused;
    public event Action         OnGameResumed;
    public event Action         OnGameRestarted;
    public event Action<string> OnSceneChanged;
    public event Action<int>    OnScoreChanged;

    int _score = 0;
    bool _isGamePaused = false;
    bool _isGameOver   = false;



    private void OnEnable()
    {
        DeathZone.OnPlayerCollided += OnPlayerCollidedWithDeathZone;
        ScoreZone.OnPlayerCollided += OnPlayerCollidedWithScoreArea;
    }

    private void OnDisable()
    {
        DeathZone.OnPlayerCollided += OnPlayerCollidedWithDeathZone;
        ScoreZone.OnPlayerCollided += OnPlayerCollidedWithScoreArea;
    }

    private void Update()
    {
        if (_isGameOver) return;

        if (!Input.GetKeyDown(_pauseKey)) return;

        _isGamePaused = !_isGamePaused;

        if (_isGamePaused)
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



    private void OnPlayerCollidedWithDeathZone(Player player, Collider2D collider)
    {
        SetGameOver();
    }

    private void OnPlayerCollidedWithScoreArea()
    {
        IncrementScore();
    }

    private void IncrementScore()
    {
        _score++;

        OnScoreChanged?.Invoke(_score);
    }

    public void RestartGame()
    {
        Resume();

        var currentScene = SceneManager.GetActiveScene();

        SceneManager.LoadSceneAsync(currentScene.name);

        _isGameOver = false;

        OnGameRestarted?.Invoke();
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);

        OnSceneChanged?.Invoke(sceneName);
    }

    public void SetGameOver()
    {
        Pause();
        ResetScore();

        _isGameOver = true;

        OnGameOver?.Invoke();
    }

    void ResetScore()
    {
        _score = 0;
    }

    void Pause()
    {
        Time.timeScale = 0;

        AudioListener.pause = true;
    }

    void Resume()
    {
        Time.timeScale = 1;

        AudioListener.pause = false;
    }
}
