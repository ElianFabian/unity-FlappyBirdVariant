using UnityEngine;

namespace Assets.Scripts.PlayerScripts
{
    [DisallowMultipleComponent]
    public class PlayerMovement : BasePlayerComponent
    {
        Rigidbody2D _rigidBody;

        float _jumpVelocity;

        Quaternion _fordwardRotation;
        Quaternion _downRotation;



        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
            _jumpVelocity = player.action.JumpVelocity;

            _fordwardRotation = Quaternion.identity;
            _downRotation     = Quaternion.Euler(0, 0, 90);
        }

        private void Update()
        {
            HandleRotation();
        }



        void HandleRotation()
        {
            var velocity = _rigidBody.velocity;

            var rotationRate = Mathf.InverseLerp(_jumpVelocity, -_jumpVelocity, velocity.y);

            transform.rotation = Quaternion.Lerp
            (
                _fordwardRotation,
                _downRotation,
                rotationRate
            );
        }
    }
}
