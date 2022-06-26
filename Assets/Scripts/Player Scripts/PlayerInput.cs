using Assets.Scripts.ScriptableObjects.Events;
using System;
using UnityEngine;



namespace Assets.Scripts.PlayerScripts
{
    [DisallowMultipleComponent]
    public class PlayerInput : BasePlayerComponent
    {
        [SerializeField] KeyCode _jumpKey = KeyCode.Space;



        private void Update()
        {
            if (Input.GetKeyDown(_jumpKey)) player.inputEventChannel.RaiseJumpKeyPressedEvent();
        }
    }
}
