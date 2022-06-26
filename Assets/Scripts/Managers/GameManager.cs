﻿using Assets.Scripts.PlayerScripts;
using Assets.Scripts.ScriptableObjects.Events;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;



[DisallowMultipleComponent]
public class GameManager : MonoBehaviour
{
    #region Fields

    [SerializeField] GameEventChannelSO            _gameEventChannel;
    [SerializeField] UIEventChannelSO              _uiEventChannel;
    [SerializeField] PlayerCollisionEventChannelSO _playerCollisionEventChannel;

    [SerializeField] KeyCode _pauseKey = KeyCode.Escape;

    [Scene]
    [SerializeField] string _menuSceneName;

    GameState _gameState = GameState.Playing;
    int       _score     = 0;

    #endregion

    #region Unity event functions

    private void OnEnable()
    {
        _playerCollisionEventChannel.deathZone.OnTriggerEnter2D += OnPlayerCollidedWithDeathZone;
        _playerCollisionEventChannel.scoreZone.OnTriggerEnter2D += OnPlayerCollidedWithScoreZone;

        _uiEventChannel.BtnGoToMenu_Click += BtnGoToMenu_Click;
        _uiEventChannel.BtnTryAgain_Click += BtnTryAgain_Click;
    }

    private void OnDisable()
    {
        _playerCollisionEventChannel.deathZone.OnTriggerEnter2D -= OnPlayerCollidedWithDeathZone;
        _playerCollisionEventChannel.scoreZone.OnTriggerEnter2D -= OnPlayerCollidedWithScoreZone;

        _uiEventChannel.BtnGoToMenu_Click -= BtnGoToMenu_Click;
        _uiEventChannel.BtnTryAgain_Click -= BtnTryAgain_Click;
    }

    private void Update()
    {
        if (_gameState == GameState.GameOver) return;

        if (!Input.GetKeyDown(_pauseKey)) return;

        _gameState = SwitchGameState();

        if (_gameState == GameState.Paused)
        {
            Pause();
            _gameEventChannel.RaiseGamePausedEvent();
        }
        else if (_gameState == GameState.Playing)
        {
            Resume();
            _gameEventChannel.RaiseGameResumedEvent();
        }
    }

    #endregion

    #region Event functions

    private void OnPlayerCollidedWithDeathZone(Player player, Collider2D collider)
    {
        SetGameOver();
    }

    private void OnPlayerCollidedWithScoreZone(Player player, Collider2D collider)
    {
        IncrementScore();
    }

    private void BtnGoToMenu_Click()
    {
        SceneManager.LoadSceneAsync(_menuSceneName);

        _gameEventChannel.RaiseSceneChangedEvent(_menuSceneName);
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

        _gameEventChannel.RaiseScoreChangedEvent(_score);
    }

    void RestartGame()
    {
        Resume();

        var currentScene = SceneManager.GetActiveScene();

        SceneManager.LoadSceneAsync(currentScene.name);

        _gameState = GameState.Playing;

        _gameEventChannel.RaiseGameRestartedEvent();
    }

    void SetGameOver()
    {
        Pause();

        _gameState = GameState.GameOver;

        _gameEventChannel.RaiseGameOverEvent();
    }

    void Pause()
    {
        Time.timeScale = 0;
    }

    void Resume()
    {
        Time.timeScale = 1;
    }

    GameState SwitchGameState() => _gameState == GameState.Playing ? GameState.Paused : GameState.Playing;

    #endregion
}


enum GameState
{
    Paused, Playing, GameOver
}