﻿using Assets.Scripts.ScriptableObjects.Data;
using Assets.Scripts.ScriptableObjects.Events;
using System;
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
            _gameEventChannel.OnGameResumed += SwitchToGamePlay;
            _gameEventChannel.OnGameOver    += SwitchToNone;
        }

        private void OnDisable()
        {
            _gameEventChannel.OnGamePaused  -= SwitchToPause;
            _gameEventChannel.OnGameResumed -= SwitchToGamePlay;
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
            if (Input.GetKeyDown(_keyBinding.pauseKey)) _uiEventChannel.RaisePauseToggledEvent();
        }

        void HandlePlayerInput()
        {
            if (Input.GetKeyDown(_keyBinding.jumpKey)) _playerInputEventChannel.RaiseJumpEvent();
        }

        void SwitchToGamePlay() => _currentActionMap = ActionMap.GamePlay;
        void SwitchToPause() => _currentActionMap = ActionMap.Pause;
        void SwitchToNone() => _currentActionMap = ActionMap.None;
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
