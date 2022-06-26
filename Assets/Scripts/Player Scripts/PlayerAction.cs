using System;
using UnityEngine;



namespace Assets.Scripts.PlayerScripts
{
    [DisallowMultipleComponent]
    public class PlayerAction : BasePlayerComponent
    {
        [SerializeField] float maxJumpHeight = 2;

        public static event Action OnJump;
        
        Rigidbody2D _rigidbody;



        internal float JumpVelocity => Mathf.Sqrt(-2f * Player.GRAVITY * maxJumpHeight);



        protected override void Awake()
        {
            base.Awake();

            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            PlayerInput.OnJumpKeyDown += OnJumpKeyDown;
        }

        private void OnDisable()
        {
            PlayerInput.OnJumpKeyDown -= OnJumpKeyDown;
        }



        void OnJumpKeyDown()
        {
            Jump();
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
