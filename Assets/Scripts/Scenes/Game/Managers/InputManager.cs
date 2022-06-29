using System;
using Assets.Scripts.Scenes.Game.Binding;
using Assets.Scripts.Scenes.Game.PlayerComponents;
using UnityEngine;

namespace Assets.Scripts.Scenes.Game.Managers
{
    [DisallowMultipleComponent]
    public class InputManager : MonoBehaviour
    {
        #region Field

        public static event Action OnPauseToggled;

        ActionMap _currentActionMap = ActionMap.GamePlay;

        #endregion

        #region Unity event functions

        private void OnEnable()
        {
            GameManager.OnGamePaused  += SwitchToPause;
            GameManager.OnGameResumed += SwitchToGamePlay;
            GameManager.OnGameOver    += SwitchToNone;
        }

        private void OnDisable()
        {
            GameManager.OnGamePaused  -= SwitchToPause;
            GameManager.OnGameResumed -= SwitchToGamePlay;
            GameManager.OnGameOver    -= SwitchToNone;
        }

        private void Update()
        {
            HandleSwitchActionMap();
        }

        #endregion

        #region Methods

        void HandleSwitchActionMap()
        {
            switch (_currentActionMap)
            {
                case ActionMap.GamePlay:
                    HandlePauseInput();
                    HandlePlayerInput();
                    break;
                case ActionMap.Pause:
                    HandlePauseInput();
                    break;
            }
        }

        void HandlePauseInput()
        {
            if (Input.GetKeyDown(KeyBinding.keys.pauseKey)) OnPauseToggled?.Invoke();
        }

        void HandlePlayerInput()
        {
            PlayerInput.HandleInput();
        }

        void SwitchToGamePlay() => _currentActionMap = ActionMap.GamePlay;
        void SwitchToPause() => _currentActionMap = ActionMap.Pause;
        void SwitchToNone() => _currentActionMap = ActionMap.None;

        #endregion
    }



    [Flags]
    enum ActionMap
    {
        None = 0,
        Player = 1 << 0,
        Pause = 1 << 1,

        GamePlay = Player | Pause
    }
}
