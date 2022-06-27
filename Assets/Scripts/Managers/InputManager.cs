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

        [SerializeField] PlayerInputDataSO _playerInputData;
        [SerializeField] UIInputDataSO     _uiInputData;

        bool _isPlayerInputAvailable = true;
        bool _isUIInputAvailable     = true;



        private void OnEnable()
        {
            _gameEventChannel.OnGamePaused  += DisablePlayerInput;
            _gameEventChannel.OnGameOver    += DisablePlayerInput;
            _gameEventChannel.OnGameOver    += DisableUIInput;
            _gameEventChannel.OnGameResumed += EnablePlayerInput;
        }

        private void OnDisable()
        {
            _gameEventChannel.OnGamePaused  -= DisablePlayerInput;
            _gameEventChannel.OnGameOver    -= DisablePlayerInput;
            _gameEventChannel.OnGameOver    -= DisableUIInput;
            _gameEventChannel.OnGameResumed -= EnablePlayerInput;
        }

        private void Update()
        {
            if (_isPlayerInputAvailable) HandlePlayerInput();

            if (_isUIInputAvailable) HandleUIInput();
        }



        void HandlePlayerInput()
        {
            if (Input.GetKeyDown(_playerInputData.jumpKey)) _playerInputEventChannel.RaiseJumpEvent();
        }

        void HandleUIInput()
        {
            if (Input.GetKeyDown(_uiInputData.pauseKey)) _uiEventChannel.ReaiseTogglePauseEvent();
        }

        void EnablePlayerInput() => _isPlayerInputAvailable = true;

        void DisablePlayerInput() => _isPlayerInputAvailable = false;

        void DisableUIInput() => _isUIInputAvailable = false;
    }
}
