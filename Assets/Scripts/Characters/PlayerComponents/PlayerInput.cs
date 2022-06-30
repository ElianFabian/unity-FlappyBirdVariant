using System;
using Assets.Scripts.Binding;
using UnityEngine;

namespace Assets.Scripts.Characters.PlayerComponents
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
