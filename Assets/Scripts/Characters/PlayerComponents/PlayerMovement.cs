using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Characters.PlayerComponents
{
    [DisallowMultipleComponent]
    public class PlayerMovement : MonoBehaviour, IPlayeMovement
    {
        const float Gravity = -9.81f;

        [SerializeField] float _maxJumpHeight = 1.75f;

        Rigidbody2D _rigidBody;

        float _startJumpVelocity;

        Quaternion _fordwardRotation;
        Quaternion _downRotation;

        public float JumpVelocity => Mathf.Sqrt(-2 * Gravity * _maxJumpHeight);



        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _startJumpVelocity = JumpVelocity;
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
