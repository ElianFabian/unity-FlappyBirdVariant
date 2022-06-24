using Assets.Scripts.Util;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts.PipeScripts;
using Assets.Scripts.PlayerScripts;
using NaughtyAttributes;



[DisallowMultipleComponent]
public class GameManager : SingletonPersistent<GameManager>
{
    #region Fields

    [SerializeField] KeyCode _pauseKey = KeyCode.Escape;

    [Scene]
    [SerializeField] string _menuSceneName;

    public static event Action         OnGameOver;
    public static event Action         OnGamePaused;
    public static event Action         OnGameResumed;
    public static event Action         OnGameRestarted;
    public static event Action<string> OnSceneChanged;
    public static event Action<int>    OnScoreChanged;

    int _score = 0;
    bool _isGamePaused = false;
    bool _isGameOver   = false;

    #endregion

    #region Unity event functions

    private void OnEnable()
    {
        DeathZone.OnPlayerCollided += OnPlayerCollidedWithDeathZone;
        ScoreZone.OnPlayerCollided += OnPlayerCollidedWithScoreArea;

        UIManager.BtnGoToMenu_Click += BtnGoToMenu_Click;
        UIManager.BtnTryAgain_Click += BtnTryAgain_Click;
    }

    private void OnDisable()
    {
        DeathZone.OnPlayerCollided -= OnPlayerCollidedWithDeathZone;
        ScoreZone.OnPlayerCollided -= OnPlayerCollidedWithScoreArea;

        UIManager.BtnGoToMenu_Click -= BtnGoToMenu_Click;
        UIManager.BtnTryAgain_Click -= BtnTryAgain_Click;
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

    #endregion

    #region Event functions

    private void OnPlayerCollidedWithDeathZone(Player player, Collider2D collider)
    {
        SetGameOver();
    }

    private void OnPlayerCollidedWithScoreArea()
    {
        IncrementScore();
    }

    private void BtnGoToMenu_Click()
    {
        SceneManager.LoadSceneAsync(_menuSceneName);

        OnSceneChanged?.Invoke(_menuSceneName);
    }

    private void BtnTryAgain_Click()
    {
        RestartGame();
    }

    #endregion

    #region Methods

    void IncrementScore()
    {
        _score++;

        OnScoreChanged?.Invoke(_score);
    }

    void RestartGame()
    {
        Resume();

        var currentScene = SceneManager.GetActiveScene();

        SceneManager.LoadSceneAsync(currentScene.name);

        _isGameOver = false;

        OnGameRestarted?.Invoke();
    }

    void SetGameOver()
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

    #endregion
}
