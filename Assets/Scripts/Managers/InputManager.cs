using Assets.Scripts.ScriptableObjects.Data;
using Assets.Scripts.ScriptableObjects.Events;
using UnityEngine;



namespace Assets.Scripts.Managers
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] PlayerActionEventChannelSO _playerInputEventChannel;
        [SerializeField] UIEventChannelSO           _uiEventChannel;
        [SerializeField] GameEventChannelSO         _gameEventChannel;

        [SerializeField] KeyBindingDataSo _keyBinding;

        ActionMap _currentActionMap = ActionMap.Player;



        private void OnEnable()
        {
            _gameEventChannel.OnGamePaused  += SwitchToPause;
            _gameEventChannel.OnGameResumed += SwitchToPlayer;
            _gameEventChannel.OnGameOver    += SwitchToNone;
        }

        private void OnDisable()
        {
            _gameEventChannel.OnGamePaused  -= SwitchToPause;
            _gameEventChannel.OnGameResumed -= SwitchToPlayer;
            _gameEventChannel.OnGameOver    -= SwitchToNone;
        }

        private void Update()
        {
            HandleSwitchActionMap();
        }



        void HandleSwitchActionMap()
        {
            switch (_currentActionMap)
            {
                case ActionMap.Player:
                    HandleGlobalInput();
                    HandlePlayerInput();
                    break;
                case ActionMap.Pause:
                    HandleGlobalInput();
                    break;
            }
        }

        void HandleGlobalInput()
        {
            if (Input.GetKeyDown(_keyBinding.pauseKey)) _uiEventChannel.ReaiseTogglePauseEvent();
        }

        void HandlePlayerInput()
        {
            if (Input.GetKeyDown(_keyBinding.jumpKey)) _playerInputEventChannel.RaiseJumpEvent();
        }

        void SwitchToPlayer() => _currentActionMap = ActionMap.Player;
        void SwitchToPause() => _currentActionMap = ActionMap.Pause;
        void SwitchToNone() => _currentActionMap = ActionMap.None;
    }
}

enum ActionMap
{
    Player, Pause, None
}
