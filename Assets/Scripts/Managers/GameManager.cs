using Assets.Scripts;
using Assets.Scripts.EventChannels;
using Assets.Scripts.PlayerScripts;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;



[DisallowMultipleComponent]
public class GameManager : MonoBehaviour
{
    #region Fields

    [Scene]
    [SerializeField] string _menuSceneName;

    GameState _gameState = GameState.Playing;
    int       _score     = 0;

    #endregion

    #region Unity event functions

    private void OnEnable()
    {
        DeathZone.OnPlayerTriggerEnter2D += OnPlayerTriggerEnter2DWithDeathZone;
        ScoreZone.OnPlayerTriggerEnter2D += OnPlayerTriggerEnter2DWithScoreZone;

        UIEvents.BtnGoToMenu_Click += GoToMenu;
        UIEvents.BtnTryAgain_Click += RestartGame;
        UIEvents.OnPauseToggled    += OnPauseToggled;
    }

    private void OnDisable()
    {
        DeathZone.OnPlayerTriggerEnter2D -= OnPlayerTriggerEnter2DWithDeathZone;
        ScoreZone.OnPlayerTriggerEnter2D -= OnPlayerTriggerEnter2DWithScoreZone;

        UIEvents.BtnGoToMenu_Click -= GoToMenu;
        UIEvents.BtnTryAgain_Click -= RestartGame;
        UIEvents.OnPauseToggled    -= OnPauseToggled;
    }

    #endregion

    #region Event functions

    private void OnPauseToggled()
    {
        _gameState = ToggleGameState();

        if (_gameState == GameState.Paused)
        {
            Pause();
            GameEvents.RaiseGamePausedEvent();
        }
        else if (_gameState == GameState.Playing)
        {
            Resume();
            GameEvents.RaiseGameResumedEvent();
        }
    }

    private void OnPlayerTriggerEnter2DWithDeathZone(Player player, Collider2D collider)
    {
        SetGameOver();
    }

    private void OnPlayerTriggerEnter2DWithScoreZone(Player player, Collider2D collider)
    {
        IncrementScore();
    }

    #endregion

    #region Methods

    void IncrementScore()
    {
        _score++;

        GameEvents.RaiseScoreChangedEvent(_score);
    }

    private void GoToMenu()
    {
        SceneManager.LoadSceneAsync(_menuSceneName);

        GameEvents.RaiseSceneChangedEvent(_menuSceneName);
    }

    void RestartGame()
    {
        Resume();

        var currentScene = SceneManager.GetActiveScene();

        SceneManager.LoadSceneAsync(currentScene.name);

        _gameState = GameState.Playing;

        GameEvents.RaiseGameRestartedEvent();
    }

    void SetGameOver()
    {
        Pause();

        _gameState = GameState.GameOver;

        GameEvents.RaiseGameOverEvent();
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