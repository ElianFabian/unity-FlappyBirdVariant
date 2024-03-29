﻿using Assets.Scripts.Events.ScriptableObjects;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Managers
{
    [DisallowMultipleComponent]
    public class GameManager : MonoBehaviour
    {
        #region Fields

        [SerializeField] VoidEventChannelSO _onGameStarted;
        [SerializeField] VoidEventChannelSO _onGamePaused;
        [SerializeField] VoidEventChannelSO _onGameResumed;
        [SerializeField] VoidEventChannelSO _onGameOver;
        [SerializeField] VoidEventChannelSO _onGameRestarted;

        [Scene]
        [SerializeField] string _menuSceneName;

        GameState _gameState = GameState.Playing;

        #endregion

        #region Unity events

        private void Start()
        {
            _onGameStarted.RaiseEvent();

            Resume();

            _gameState = GameState.Playing;
        }

        #endregion

        #region Methods

        public void GoToMenu()
        {
            SceneManager.LoadSceneAsync(_menuSceneName);
        }

        public void RestartGame()
        {
            Resume();

            _gameState = GameState.Playing;

            _onGameRestarted.RaiseEvent();

            var currentScene = SceneManager.GetActiveScene().name;

            SceneManager.LoadSceneAsync(currentScene);
        }

        public void TogglePause()
        {
            _gameState = ToggleGameState();

            switch (_gameState)
            {
                case GameState.Paused:
                    Pause();
                    _onGamePaused.RaiseEvent();
                    break;
                case GameState.Playing:
                    Resume();
                    _onGameResumed.RaiseEvent();
                    break;
            }
        }

        public void SetGameOver()
        {
            Pause();

            _gameState = GameState.GameOver;

            _onGameOver.RaiseEvent();
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
