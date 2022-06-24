using UnityEngine;
using System;



namespace Assets.Scripts.PlayerScripts
{
    [DisallowMultipleComponent]
    public class PlayerAction : BasePlayerComponent
    {
        [SerializeField] float maxJumpHeight = 2;

        public static event Action OnJump;
        
        Rigidbody2D _rigidbody;



        internal float JumpVelocity { get => Mathf.Sqrt(-2f * Player.GRAVITY * maxJumpHeight); }




        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }



        public void Jump()
        {
            var newVelocity = _rigidbody.velocity;

            newVelocity.y = JumpVelocity;

            _rigidbody.velocity = newVelocity;

            OnJump?.Invoke();
        }
    }
}
