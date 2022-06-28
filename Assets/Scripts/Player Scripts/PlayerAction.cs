using UnityEngine;



namespace Assets.Scripts.PlayerScripts
{
    [DisallowMultipleComponent]
    public class PlayerAction : BasePlayerComponent
    {
        [SerializeField] float _maxJumpHeight = 1.75f;

        Rigidbody2D _rigidbody;



        internal float JumpVelocity => Mathf.Sqrt(-2f * Player.GRAVITY * _maxJumpHeight);



        protected override void Awake()
        {
            base.Awake();

            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            player.inputEventChannel.OnJump += Jump;
        }

        private void OnDisable()
        {
            player.inputEventChannel.OnJump -= Jump;
        }



        public void Jump()
        {
            var newVelocity = _rigidbody.velocity;

            newVelocity.y = JumpVelocity;

            _rigidbody.velocity = newVelocity;
        }
    }
}
