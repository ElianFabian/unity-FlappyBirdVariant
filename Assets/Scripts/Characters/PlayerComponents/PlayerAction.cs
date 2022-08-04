using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Characters.PlayerComponents
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerAction : MonoBehaviour, IPlayerAction
    {
        Rigidbody2D _rigidbody;

        IPlayeMovement _movement;


        protected void Awake()
        {
            _movement  = GetComponent<IPlayeMovement>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }



        public void Jump()
        {
            var newVelocity = _rigidbody.velocity;

            newVelocity.y = _movement.JumpVelocity;

            _rigidbody.velocity = newVelocity;
        }
    }
}
