using System;
using Assets.Scripts.Scenes.Game.Binding;
using UnityEngine;

namespace Assets.Scripts.Scenes.Game.PlayerComponents
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
