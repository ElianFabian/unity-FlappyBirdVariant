using UnityEngine;
using System;



namespace Assets.Scripts.PlayerScripts
{
    [DisallowMultipleComponent]
    public class PlayerInput : BasePlayerComponent
    {
        public static event Action OnJumpKeyDown;

        public KeyCode jumpKey = KeyCode.Space;



        private void Update()
        {
            if (Input.GetKeyDown(jumpKey)) OnJumpKeyDown?.Invoke();
        }
    }
}
