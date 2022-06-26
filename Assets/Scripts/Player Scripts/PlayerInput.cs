using UnityEngine;
using System;
using Assets.Scripts.ScriptableObjects.Events;



namespace Assets.Scripts.PlayerScripts
{
    [DisallowMultipleComponent]
    public class PlayerInput : BasePlayerComponent
    {
        public static event Action OnJumpKeyDown;

        [SerializeField] GameEventChannelSO _gameEventChannel;

        public KeyCode jumpKey = KeyCode.Space;



        private void Update()
        {
            if (Input.GetKeyDown(jumpKey)) OnJumpKeyDown?.Invoke();
        }
    }
}
