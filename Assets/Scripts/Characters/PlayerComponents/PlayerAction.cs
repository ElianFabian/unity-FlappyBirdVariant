using UnityEngine;

namespace Assets.Scripts.Characters.PlayerComponents
{
    [DisallowMultipleComponent]
    public class PlayerAction : BasePlayerComponent
    {
        [SerializeField] float _maxJumpHeight = 1.75f;

        Rigidbody2D _rigidbody;



        internal float JumpVelocity => Mathf.Sqrt(-2f * Player.Gravity * _maxJumpHeight);



        protected override void Awake()
        {
            base.Awake();

            _rigidbody = GetComponent<Rigidbody2D>();
        }



        public void Jump()
        {
            var newVelocity = _rigidbody.velocity;

            newVelocity.y = JumpVelocity;

            _rigidbody.velocity = newVelocity;
        }
    }
}
