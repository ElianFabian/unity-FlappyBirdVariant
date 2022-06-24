using UnityEngine;

namespace Assets.Scripts.PlayerScripts
{
    [DisallowMultipleComponent]
    public class PlayerMovement : BasePlayerComponent
    {
        Rigidbody2D _rigidBody;

        float _jumpVelocity;



        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
            _jumpVelocity = player.action.JumpVelocity;
        }

        private void Update()
        {
            if (player.isJumpPressed) player.action.Jump();

            HandleRotation();
        }


        void HandleRotation()
        {
            var velocity = _rigidBody.velocity;

            var bottom = transform.position + Vector3.down;

            var newRotation = LookAt2D(bottom);

            var rotationRate = Mathf.InverseLerp(_jumpVelocity, -_jumpVelocity, velocity.y);

            transform.rotation = Quaternion.Lerp
            (
                Quaternion.identity,
                newRotation,
                rotationRate
            );
        }

        Quaternion LookAt2D(Vector3 targetPosition)
        {
            var previousRight = transform.right;
            transform.right = targetPosition - transform.position;

            var lookAt2DRotation = transform.rotation;

            transform.right = previousRight;

            return lookAt2DRotation;
        }
    }
}
