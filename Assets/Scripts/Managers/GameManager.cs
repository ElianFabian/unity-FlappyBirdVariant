using Assets.Scripts.PlayerScripts;
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

    [Scene]
    [SerializeField] string _menuSceneName;

    GameState _gameState = GameState.Playing;
    int       _score     = 0;

    #endregion

    #region Unity event functions

    private void OnEnable()
    {
        _playerCollisionEventChannel.deathZone.OnTriggerEnter2D += OnPlayerTriggerEnter2DWithDeathZone;
        _playerCollisionEventChannel.scoreZone.OnTriggerEnter2D += OnPlayerTriggerEnter2DdWithScoreZone;

        _uiEventChannel.BtnGoToMenu_Click += GoToMenu;
        _uiEventChannel.BtnTryAgain_Click += RestartGame;
        _uiEventChannel.OnPauseToggled    += OnPauseToggled;
    }

    private void OnDisable()
    {
        _playerCollisionEventChannel.deathZone.OnTriggerEnter2D -= OnPlayerTriggerEnter2DWithDeathZone;
        _playerCollisionEventChannel.scoreZone.OnTriggerEnter2D -= OnPlayerTriggerEnter2DdWithScoreZone;

        _uiEventChannel.BtnGoToMenu_Click -= GoToMenu;
        _uiEventChannel.BtnTryAgain_Click -= RestartGame;
        _uiEventChannel.OnPauseToggled    -= OnPauseToggled;
    }

    #endregion

    #region Event functions

    private void OnPauseToggled()
    {
        _gameState = ToggleGameState();

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

    private void OnPlayerTriggerEnter2DWithDeathZone(Player player, Collider2D collider)
    {
        SetGameOver();
    }

    private void OnPlayerTriggerEnter2DdWithScoreZone(Player player, Collider2D collider)
    {
        IncrementScore();
    }

    #endregion

    #region Methods

    void IncrementScore()
    {
        _score++;

        _gameEventChannel.RaiseScoreChangedEvent(_score);
    }

    private void GoToMenu()
    {
        SceneManager.LoadSceneAsync(_menuSceneName);

        _gameEventChannel.RaiseSceneChangedEvent(_menuSceneName);
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

    void Pause() => Time.timeScale = 0;

    void Resume() => Time.timeScale = 1;

    GameState ToggleGameState() => _gameState == GameState.Playing ? GameState.Paused : GameState.Playing;

    #endregion
}



enum GameState
{
    Playing, Paused, GameOver
}