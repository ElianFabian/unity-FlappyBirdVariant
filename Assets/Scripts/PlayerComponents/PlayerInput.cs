using Assets.Scripts.Data;
using System;
using UnityEngine;



namespace Assets.Scripts.PlayerComponents
{
    public class PlayerInput : BasePlayerComponent
    {
        public static event Action OnJump;



        public static void HandleInput()
        {
            if (Input.GetKeyDown(KeyBinding.keys.jumpKey)) OnJump?.Invoke();
        }
    }
}
