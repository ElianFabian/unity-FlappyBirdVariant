using Assets.Scripts.Util;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts.PipeScripts;
using Assets.Scripts.PlayerScripts;



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
        DeadZone.OnPlayerCollided += OnPlayerCollidedWithDeadZone;
    }

    private void OnDisable()
    {
        DeadZone.OnPlayerCollided += OnPlayerCollidedWithDeadZone;
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



    void OnPlayerCollidedWithDeadZone(Player player, Collider2D collider)
    {
        SetGameOver();
    }

    public void IncrementScore()
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
    }

    void Resume()
    {
        Time.timeScale = 1;
    }
}
