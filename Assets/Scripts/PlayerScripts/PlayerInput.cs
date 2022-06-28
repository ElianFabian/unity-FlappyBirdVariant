using Assets.Scripts.ScriptableObjects.Data;
using System;
using UnityEngine;



namespace Assets.Scripts.PlayerScripts
{
    public class PlayerInput : BasePlayerComponent
    {
        public static event Action OnJump;

        public static KeyBindingDataSO KeyBinding;

        [SerializeField] KeyBindingDataSO _keyBinding;



        protected override void Awake()
        {
            base.Awake();

            KeyBinding = _keyBinding;
        }



        public static void HandleInput()
        {
            if (Input.GetKeyDown(KeyBinding.jumpKey)) OnJump?.Invoke();
        }
    }
}
