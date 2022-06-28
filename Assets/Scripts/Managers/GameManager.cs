using Assets.Scripts.PlayerScripts;
using NaughtyAttributes;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;



namespace Assets.Scripts.Managers
{
    [DisallowMultipleComponent]
    public class GameManager : MonoBehaviour
    {
        #region Fields

        public static event Action
                OnGameOver,
                OnGamePaused,
                OnGameResumed,
                OnGameRestarted;
        public static event Action<string> OnSceneChanged;
        public static event Action<int>    OnScoreChanged;

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

            UIManager.BtnGoToMenu_Click += GoToMenu;
            UIManager.BtnTryAgain_Click += RestartGame;
            InputManager.OnPauseToggled    += OnPauseToggled;
        }

        private void OnDisable()
        {
            DeathZone.OnPlayerTriggerEnter2D -= OnPlayerTriggerEnter2DWithDeathZone;
            ScoreZone.OnPlayerTriggerEnter2D -= OnPlayerTriggerEnter2DWithScoreZone;

            UIManager.BtnGoToMenu_Click -= GoToMenu;
            UIManager.BtnTryAgain_Click -= RestartGame;
            InputManager.OnPauseToggled    -= OnPauseToggled;
        }

        #endregion

        #region Event functions

        private void OnPauseToggled()
        {
            _gameState = ToggleGameState();

            if (_gameState == GameState.Paused)
            {
                Pause();
                OnGamePaused?.Invoke();
            }
            else if (_gameState == GameState.Playing)
            {
                Resume();
                OnGameResumed?.Invoke();
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

            OnScoreChanged?.Invoke(_score);
        }

        private void GoToMenu()
        {
            SceneManager.LoadSceneAsync(_menuSceneName);

            OnSceneChanged?.Invoke(_menuSceneName);
        }

        void RestartGame()
        {
            Resume();

            var currentScene = SceneManager.GetActiveScene();

            SceneManager.LoadSceneAsync(currentScene.name);

            _gameState = GameState.Playing;

            OnGameRestarted?.Invoke();
        }

        void SetGameOver()
        {
            Pause();

            _gameState = GameState.GameOver;

            OnGameOver?.Invoke();
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
}
