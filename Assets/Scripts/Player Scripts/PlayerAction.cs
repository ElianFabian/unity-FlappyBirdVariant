using UnityEngine;
using System;



namespace Assets.Scripts.PlayerScripts
{
    [DisallowMultipleComponent]
    public class PlayerAction : BasePlayerComponent
    {
        public event Action OnJump;



        public void Jump()
        {
            var newVelocity = player.rigidbody.velocity;

            newVelocity.y = Mathf.Sqrt(-2f * Player.GRAVITY * player.maxJumpHeight);

            player.rigidbody.velocity = newVelocity;

            OnJump?.Invoke();
        }
    }
}
