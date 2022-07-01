using Assets.Scripts.Data.ScriptableObjects;
using Assets.Scripts.Events.ScriptableObjects;
using System;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    [DisallowMultipleComponent]
    public class InputManager : MonoBehaviour
    {
        #region Field

        [SerializeField] KeyDataSO _keyData;

        [SerializeField] VoidEventChannelSO _onHandlePlayerInput;
        [SerializeField] VoidEventChannelSO _onPauseToggled;

        ActionMap _currentActionMap = ActionMap.GamePlay;

        #endregion

        #region Unity event functions

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
            if (Input.GetKeyDown(_keyData.pauseKey)) _onPauseToggled.RaiseEvent();
        }

        void HandlePlayerInput() => _onHandlePlayerInput.RaiseEvent();

        public void SwitchToGamePlay() => _currentActionMap = ActionMap.GamePlay;
        public void SwitchToPause() => _currentActionMap = ActionMap.Pause;
        public void SwitchToNone() => _currentActionMap = ActionMap.None;

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
