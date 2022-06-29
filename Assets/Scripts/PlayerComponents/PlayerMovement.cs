using UnityEngine;



namespace Assets.Scripts.PlayerComponents
{
    [DisallowMultipleComponent]
    public class PlayerMovement : BasePlayerComponent
    {
        Rigidbody2D _rigidBody;

        float _startJumpVelocity;

        Quaternion _fordwardRotation;
        Quaternion _downRotation;



        protected override void Awake()
        {
            base.Awake();

            _rigidBody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _startJumpVelocity = player.action.JumpVelocity;
            _fordwardRotation  = Quaternion.identity;
            _downRotation      = Quaternion.Euler(0, 0, -90);
        }

        private void Update()
        {
            HandleRotation();
        }



        void HandleRotation()
        {
            var velocity = _rigidBody.velocity;

            var rotationRate = Mathf.InverseLerp(_startJumpVelocity, -_startJumpVelocity * 2, velocity.y);

            transform.rotation = Quaternion.Lerp(_fordwardRotation, _downRotation, rotationRate);
        }
    }
}
