using Assets.Scripts.EventChannels;
using Assets.Scripts.ScriptableObjects.Data;
using System;
using UnityEngine;



namespace Assets.Scripts.Managers
{
    [DisallowMultipleComponent]
    public class InputManager : MonoBehaviour
    {
        #region Field

        [SerializeField] KeyBindingDataSo _keyBinding;

        ActionMap _currentActionMap = ActionMap.GamePlay;

        #endregion

        #region Unity event functions

        private void OnEnable()
        {
            GameEvents.OnGamePaused  += SwitchToPause;
            GameEvents.OnGameResumed += SwitchToGamePlay;
            GameEvents.OnGameOver    += SwitchToNone;
        }

        private void OnDisable()
        {
            GameEvents.OnGamePaused  -= SwitchToPause;
            GameEvents.OnGameResumed -= SwitchToGamePlay;
            GameEvents.OnGameOver    -= SwitchToNone;
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
            if (Input.GetKeyDown(_keyBinding.pauseKey)) UIEvents.RaisePauseToggledEvent();
        }

        void HandlePlayerInput()
        {
            if (Input.GetKeyDown(_keyBinding.jumpKey)) PlayerEvents.RaiseJumpEvent();
        }

        void SwitchToGamePlay() => _currentActionMap = ActionMap.GamePlay;
        void SwitchToPause() => _currentActionMap = ActionMap.Pause;
        void SwitchToNone() => _currentActionMap = ActionMap.None;

        #endregion
    }
}



[Flags]
enum ActionMap
{
    None = 0,
    Player = 1 << 0,
    Pause = 1 << 1,

    GamePlay = Player | Pause
}
