using Assets.Scripts.Util;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts;
using Assets.Scripts.PlayerScripts;
using NaughtyAttributes;
using Assets.Scripts.ScriptableObjects.Events;



[DisallowMultipleComponent]
public class GameManager : MonoBehaviour
{
    #region Fields

    [SerializeField] GameEventChannelSO            _gameEventChannel;
    [SerializeField] UIEventChannelSO              _uiEventChannel;
    [SerializeField] PlayerCollisionEventChannelSO _playerCollistionEventChannel;

    [SerializeField] PlayerInput _playerInput;

    [SerializeField] KeyCode _pauseKey = KeyCode.Escape;

    [Scene]
    [SerializeField] string _menuSceneName;

    int  _score        = 0;
    bool _isGamePaused = false;
    bool _isGameOver   = false;

    #endregion

    #region Unity event functions

    private void OnEnable()
    {
        _playerCollistionEventChannel.OnTriggerEnter2DInDeathZone += OnPlayerCollidedWithDeathZone;
        _playerCollistionEventChannel.OnTriggerEnter2DScoreZone   += OnPlayerCollidedWithScoreZone;

        _uiEventChannel.BtnGoToMenu_Click += BtnGoToMenu_Click;
        _uiEventChannel.BtnTryAgain_Click += BtnTryAgain_Click;
    }

    private void OnDisable()
    {
        _playerCollistionEventChannel.OnTriggerEnter2DInDeathZone -= OnPlayerCollidedWithDeathZone;
        _playerCollistionEventChannel.OnTriggerEnter2DScoreZone   -= OnPlayerCollidedWithScoreZone;

        _uiEventChannel.BtnGoToMenu_Click -= BtnGoToMenu_Click;
        _uiEventChannel.BtnTryAgain_Click -= BtnTryAgain_Click;
    }

    private void Update()
    {
        if (_isGameOver) return;

        if (!Input.GetKeyDown(_pauseKey)) return;

        _isGamePaused = !_isGamePaused;

        if (_isGamePaused)
        {
            Pause();
            _gameEventChannel.RaiseGamePausedEvent();
        }
        else
        {
            Resume();
            _gameEventChannel.RaiseGameResumedEvent();
        }
    }

    #endregion

    #region Event functions

    private void OnPlayerCollidedWithDeathZone(Player player, Collider2D collider)
    {
        DisablePlayerInput();

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

        _isGameOver = false;

        _gameEventChannel.RaiseGameRestartedEvent();
    }

    void SetGameOver()
    {
        Pause();

        _isGameOver = true;

        _gameEventChannel.RaiseGameOverEvent();
    }

    void Pause()
    {
        Time.timeScale = 0;

        AudioListener.pause = true;

        DisablePlayerInput();
    }

    void Resume()
    {
        Time.timeScale = 1;

        AudioListener.pause = false;

        EnablePlayerInput();
    }

    void EnablePlayerInput() => _playerInput.enabled = true;

    void DisablePlayerInput() => _playerInput.enabled = false;

    #endregion
}
