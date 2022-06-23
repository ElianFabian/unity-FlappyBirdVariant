using UnityEngine;
using System;



namespace Assets.Scripts.PlayerScripts
{
    [DisallowMultipleComponent]
    public class PlayerAction : BasePlayerComponent
    {
        [SerializeField] float maxJumpHeight = 2;

        internal event Action OnJump;
        
        Rigidbody2D _rigidbody;



        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }



        public void Jump()
        {
            var newVelocity = _rigidbody.velocity;

            newVelocity.y = Mathf.Sqrt(-2f * Player.GRAVITY * maxJumpHeight);

            _rigidbody.velocity = newVelocity;

            OnJump?.Invoke();
        }
    }
}
